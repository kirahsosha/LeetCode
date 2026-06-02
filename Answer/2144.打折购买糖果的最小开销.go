import "sort"

/*
 * @lc app=leetcode.cn id=2144 lang=golang
 *
 * [2144] 打折购买糖果的最小开销
 */

// @lc code=start
func minimumCost(cost []int) int {
	sort.Ints(cost)
	totalCost := 0
	for i := len(cost) - 1; i >= 0; i -= 3 {
		totalCost += cost[i]
		if i > 0 {
			totalCost += cost[i-1]
		}
	}
	return totalCost
}

// @lc code=end
