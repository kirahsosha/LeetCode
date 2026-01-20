/*
 * @lc app=leetcode.cn id=3314 lang=golang
 *
 * [3314] 构造最小位运算数组 I
 */

// @lc code=start
func minBitwiseArray(nums []int) []int {
	n := len(nums)
	ans := make([]int, n)
	for i := 0; i < n; i++ {
		min := int(nums[i] / 2)
		ans[i] = -1
		for j := min; j < nums[i]; j++ {
			if (j | (j + 1)) == nums[i] {
				ans[i] = j
				break
			}
		}
	}
	return ans
}

// @lc code=end
