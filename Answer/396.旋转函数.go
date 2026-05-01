/*
 * @lc app=leetcode.cn id=396 lang=golang
 *
 * [396] 旋转函数
 */

// @lc code=start
func maxRotateFunction(nums []int) int {
	n := len(nums)

	sum, f := 0, 0
	for i, v := range nums {
		sum += v
		f += i * v
	}
	
	maxF := f
	for i := n - 1; i > 0; i-- {
		f += sum - n*nums[i]
		if f > maxF {
			maxF = f
		}
	}
	return maxF
}

// @lc code=end
