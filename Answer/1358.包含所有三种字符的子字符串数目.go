/*
 * @lc app=leetcode.cn id=1358 lang=golang
 *
 * [1358] 包含所有三种字符的子字符串数目
 */

// @lc code=start
func numberOfSubstrings(s string) int {
	var last [3]int = [3]int{-1, -1, -1}
	ans := 0
	for i := 0; i < len(s); i++ {
		last[s[i]-'a'] = i
		ans += min(last[0], min(last[1], last[2])) + 1
	}
	return ans
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

// @lc code=end
