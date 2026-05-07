/*
 * @lc app=leetcode.cn id=788 lang=golang
 *
 * [788] 旋转数字
 */

// @lc code=start
func rotatedDigits(n int) int {
	// isValid[d] 表示数字 d 旋转后是否为有效数字（0,1,2,5,6,8,9）
	isValid := []bool{true, true, true, false, false, true, true, false, true, true}
	// isDiff[d] 表示数字 d 旋转后是否变为不同的数字（2,5,6,9）
	isDiff := []bool{false, false, true, false, false, true, true, false, false, true}

	count := 0
	var dfs func(num int, hasDiff bool)
	dfs = func(num int, hasDiff bool) {
		if num > n {
			return
		}
		if hasDiff {
			count++
		}
		for d := 0; d <= 9; d++ {
			if !isValid[d] {
				continue
			}
			next := num*10 + d
			// 跳过 0 本身，避免将其计入结果
			if next == 0 {
				continue
			}
			dfs(next, hasDiff || isDiff[d])
		}
	}

	dfs(0, false)
	return count
}

// @lc code=end
