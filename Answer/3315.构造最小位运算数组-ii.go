/*
 * @lc app=leetcode.cn id=3315 lang=golang
 *
 * [3315] 构造最小位运算数组 II
 */

// @lc code=start
func minBitwiseArray(nums []int) []int {
	n := len(nums)
	ans := make([]int, n)
	for i := 0; i < n; i++ {
		value := nums[i]
		if value == 2 {
			ans[i] = -1
		} else {
			t := ^value
			lowbit := t & -t
			ans[i] = value ^ (lowbit >> 1)
		}
	}
	return ans
}

// @lc code=end
