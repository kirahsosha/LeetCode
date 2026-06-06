/*
 * @lc app=leetcode.cn id=2574 lang=golang
 *
 * [2574] 左右元素和的差值
 */

// @lc code=start
func leftRightDifference(nums []int) []int {
	total := 0
	for _, v := range nums {
		total += v
	}

	leftSum := 0
	ans := make([]int, len(nums))
	for i, v := range nums {
		diff := 2*leftSum + v - total
		if diff < 0 {
			diff = -diff
		}
		ans[i] = diff
		leftSum += v
	}
	return ans
}

// @lc code=end
