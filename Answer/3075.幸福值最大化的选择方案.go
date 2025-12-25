import "sort"

/*
 * @lc app=leetcode.cn id=3075 lang=golang
 *
 * [3075] 幸福值最大化的选择方案
 */

// @lc code=start
func maximumHappinessSum(happiness []int, k int) int64 {
	sort.Slice(happiness, func(i, j int) bool {
		return happiness[i] > happiness[j]
	})
	res := int64(0)
	for i := 0; i < k; i++ {
		res += int64(max(0, happiness[i]-i))
	}
	return res
}

// @lc code=end
