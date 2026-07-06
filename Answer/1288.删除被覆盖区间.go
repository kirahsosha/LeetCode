import (
	"cmp"
	"slices"
)

/*
 * @lc app=leetcode.cn id=1288 lang=golang
 *
 * [1288] 删除被覆盖区间
 */

// @lc code=start
func removeCoveredIntervals(intervals [][]int) int {
	slices.SortFunc(intervals, func(a, b []int) int {
		return cmp.Or(a[0]-b[0], b[1]-a[1])
	})

	ans := 0
	end := 0
	for _, it := range intervals {
		if it[1] > end {
			ans++
			end = it[1]
		}
	}
	return ans
}

// @lc code=end
