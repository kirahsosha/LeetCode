/*
 * @lc app=leetcode.cn id=2110 lang=golang
 *
 * [2110] 股票平滑下跌阶段的数目
 */

// @lc code=start
func getDescentPeriods(prices []int) int64 {
	res := int64(0)
	last := 0
	current := int64(0)
	for _, price := range prices {
		if current == 0 {
			current += 1
			last = price
		} else if price == last-1 {
			current += 1
			last = price
		} else {
			res += current * (current + 1) / 2
			current = 1
			last = price
		}
	}
	res += current * (current + 1) / 2
	return res
}

// @lc code=end

