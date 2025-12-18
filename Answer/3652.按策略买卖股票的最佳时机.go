/*
 * @lc app=leetcode.cn id=3652 lang=golang
 *
 * [3652] 按策略买卖股票的最佳时机
 */

// @lc code=start
func maxProfit(prices []int, strategy []int, k int) int64 {
	res := int64(0)
	n := len(prices)
	for i := 0; i < n; i++ {
		res += int64(prices[i]) * int64(strategy[i])
	}
	t := k / 2
	max_p := res
	for i := 0; i < t; i++ {
		res -= int64(prices[i]) * int64(strategy[i])
	}
	for i := t; i < k; i++ {
		res += int64(prices[i]) * (int64(1) - int64(strategy[i]))
	}
	max_p = max(max_p, res)
	for i := 0; i < n-k; i++ {
		res += int64(prices[i]) * int64(strategy[i])
		res -= int64(prices[i+t])
		res += int64(prices[i+k]) * (int64(1) - int64(strategy[i+k]))
		max_p = max(max_p, res)
	}
	return max_p
}

// @lc code=end

