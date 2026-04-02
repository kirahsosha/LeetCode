/*
 * @lc app=leetcode.cn id=3418 lang=golang
 *
 * [3418] 机器人可以获得的最大金币数
 */

// @lc code=start
func maximumAmount(coins [][]int) int {
	m, n := len(coins), len(coins[0])

	solve := func(rows, cols int, cell func(int, int) int) int {
		const negInf = -1 << 30
		dp := make([][3]int, cols)
		for c := 0; c < cols; c++ {
			dp[c] = [3]int{negInf, negInf, negInf}
		}

		for r := 0; r < rows; r++ {
			left := [3]int{negInf, negInf, negInf}
			for c := 0; c < cols; c++ {
				up := dp[c]
				best0, best1, best2 := negInf, negInf, negInf
				if r == 0 && c == 0 {
					best0, best1, best2 = 0, 0, 0
				} else {
					best0 = max(up[0], left[0])
					best1 = max(up[1], left[1])
					best2 = max(up[2], left[2])
				}

				coin := cell(r, c)
				cur0 := best0 + coin
				cur1 := max(best1+coin, best0)
				cur2 := max(best2+coin, best1)
				cur := [3]int{cur0, cur1, cur2}
				dp[c] = cur
				left = cur
			}
		}

		last := dp[cols-1]
		return max(last[0], max(last[1], last[2]))
	}

	if n <= m {
		return solve(m, n, func(r, c int) int { return coins[r][c] })
	}
	return solve(n, m, func(r, c int) int { return coins[c][r] })
}

// @lc code=end