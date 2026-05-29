/*
 * @lc app=leetcode.cn id=3300 lang=golang
 *
 * [3300] 替换为数位和以后的最小元素
 */

// @lc code=start
func minElement(nums []int) int {
	n := len(nums)
	ans := 10000
	for i := 0; i < n; i++ {
		sum := 0
		for x := nums[i]; x > 0; x /= 10 {
			sum += x % 10
		}
		if sum < ans {
			ans = sum
		}
	}
	return ans
}

// @lc code=end
