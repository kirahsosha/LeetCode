import "math"

/*
 * @lc app=leetcode.cn id=3689 lang=golang
 *
 * [3689] 最大子数组总值 I
 */

// @lc code=start
func maxTotalValue(nums []int, k int) int64 {
	min := math.MaxInt
	max := math.MinInt
	for _, num := range nums {
		if num < min {
			min = num
		}
		if num > max {
			max = num
		}
	}
	return int64(max-min) * int64(k)
}

// @lc code=end
