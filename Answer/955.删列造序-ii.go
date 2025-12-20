/*
 * @lc app=leetcode.cn id=955 lang=golang
 *
 * [955] 删列造序 II
 */

// @lc code=start
func minDeletionSize(strs []string) int {
    n := len(strs)
	m := len(strs[0])
    cuts := make([]bool, n - 1)
    ans := 0
    for j := 0; j < m; j++ {
		check := true
		for i := 0; i < n - 1; i++ {
			if !cuts[i] && strs[i][j] > strs[i + 1][j] {
				ans++
				check = false
				break
			}
		}
		if check {
			for i := 0; i < n - 1; i++ {
				if strs[i][j] < strs[i + 1][j] {
					cuts[i] = true
				}
			}
		}
	}
	return ans
}
// @lc code=end

