import (
	"math"
	"sort"
)

/*
 * @lc app=leetcode.cn id=1877 lang=golang
 *
 * [1877] 数组中最大数对和的最小值
 */

// @lc code=start
func minPairSum(nums []int) int {
	sort.Ints(nums)
	ans := 0
	for i := 0; i < len(nums)/2; i++ {
		ans = int(math.Max(float64(ans), float64(nums[i]+nums[len(nums)-i-1])))
	}
	return ans
}

// @lc code=end
