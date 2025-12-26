/*
 * @lc app=leetcode.cn id=2483 lang=golang
 *
 * [2483] 商店的最少代价
 */

// @lc code=start
func bestClosingTime(customers string) int {
	cost := 0
	for _, v := range customers {
		if v == 'Y' {
			cost++
		}
	}
	minCost := cost
	res := 0
	for i, v := range customers {
		if v == 'Y' {
			cost -= 1
		} else {
			cost += 1
		}
		if cost < minCost {
			minCost = cost
			res = i + 1
		}
	}
	return res
}

// @lc code=end
