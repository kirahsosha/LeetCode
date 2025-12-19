/*
 * @lc app=leetcode.cn id=944 lang=golang
 *
 * [944] 删列造序
 */

// @lc code=start
func minDeletionSize(strs []string) int {
    n := len(strs[0])
	res := 0
    for i := 0; i < n; i++ {
		for j := 1; j < len(strs); j++ {
			if strs[j][i] < strs[j - 1][i] {
				res += 1
				break
			}
		}
	}
	return res
}
// @lc code=end

