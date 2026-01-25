import "sort"

/*
 * @lc app=leetcode.cn id=1984 lang=golang
 *
 * [1984] 学生分数的最小差值
 */

// @lc code=start
func minimumDifference(nums []int, k int) int {
	if k == 1 {
		return 0
	}
	sort.Ints(nums)
	ans := nums[k-1] - nums[0]
	for i := 1; i <= len(nums)-k; i++ {
		ans = min(ans, nums[i+k-1]-nums[i])
	}
	return ans
}

// @lc code=end
