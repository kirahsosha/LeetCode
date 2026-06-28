/*
 * @lc app=leetcode.cn id=1967 lang=golang
 *
 * [1967] 作为子字符串出现在单词中的字符串数目
 */

// @lc code=start
func numOfStrings(patterns []string, word string) int {
	ans := 0
	for _, p := range patterns {
		if strings.Contains(word, p) {
			ans++
		}
	}
	return ans
}

// @lc code=end
