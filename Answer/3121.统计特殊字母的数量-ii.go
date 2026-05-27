/*
 * @lc app=leetcode.cn id=3121 lang=golang
 *
 * [3121] 统计特殊字母的数量 II
 */

// @lc code=start
func numberOfSpecialChars(word string) int {
	firstUpper := [26]int{}
	lastLower := [26]int{}
	for i := 0; i < 26; i++ {
		firstUpper[i] = -1
		lastLower[i] = -1
	}
	for i := 0; i < len(word); i++ {
		c := word[i]
		if c >= 'a' && c <= 'z' {
			lastLower[c-'a'] = i
		} else if firstUpper[c-'A'] == -1 {
			firstUpper[c-'A'] = i
		}
	}
	ans := 0
	for i := 0; i < 26; i++ {
		if lastLower[i] != -1 && firstUpper[i] != -1 && lastLower[i] < firstUpper[i] {
			ans++
		}
	}
	return ans
}

// @lc code=end
