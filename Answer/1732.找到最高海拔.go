/*
 * @lc app=leetcode.cn id=1732 lang=golang
 *
 * [1732] 找到最高海拔
 */

// @lc code=start
func largestAltitude(gain []int) int {
	max := 0
	cur := 0
	for _, g := range gain {
		cur += g
		if cur > max {
			max = cur
		}
	}
	return max
}

// @lc code=end
