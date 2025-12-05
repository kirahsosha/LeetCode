/*
 * @lc app=leetcode.cn id=3432 lang=golang
 *
 * [3432] 统计元素和差值为偶数的分区方案
 */

// @lc code=start
func countPartitions(nums []int) int {
	sum := 0
	for _, i := range nums {
		sum += i
	}
	if sum%2 != 0 {
		return 0
	}
	res := 0
	left := 0
	for i := 0; i < len(nums)-1; i++ {
		left += nums[i]
		sum -= nums[i]
		if (left-sum)%2 == 0 {
			res += 1
		}
	}
	return res
}

// @lc code=end

