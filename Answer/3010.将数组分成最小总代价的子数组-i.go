import "sort"

/*
 * @lc app=leetcode.cn id=3010 lang=golang
 *
 * [3010] 将数组分成最小总代价的子数组 I
 */

// @lc code=start
func minimumCost(nums []int) int {
	n1 := nums[0]
	nums = nums[1:]
	sort.Ints(nums)
	return n1 + nums[0] + nums[1]
}

// @lc code=end
