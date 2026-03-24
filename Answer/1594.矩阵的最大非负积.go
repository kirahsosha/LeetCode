/*
 * @lc app=leetcode.cn id=1594 lang=golang
 *
 * [1594] 矩阵的最大非负积
 */

// @lc code=start
func maxProductPath(grid [][]int) int {
	const MOD int64 = 1000000007
	m := len(grid)
	n := len(grid[0])
	dp := make([][][]int64, m)
	for i := 0; i < m; i++ {
		dp[i] = make([][]int64, n)
		for j := 0; j < n; j++ {
			dp[i][j] = make([]int64, 2)
		}
	}

	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			if i == 0 && j == 0 {
				dp[i][j][0] = int64(grid[i][j])
				dp[i][j][1] = int64(grid[i][j])
			} else if i == 0 {
				maxVal := dp[i][j-1][0] * int64(grid[i][j])
				minVal := dp[i][j-1][1] * int64(grid[i][j])
				if maxVal > minVal {
					dp[i][j][0] = maxVal
					dp[i][j][1] = minVal
				} else {
					dp[i][j][0] = minVal
					dp[i][j][1] = maxVal
				}
			} else if j == 0 {
				maxVal := dp[i-1][j][0] * int64(grid[i][j])
				minVal := dp[i-1][j][1] * int64(grid[i][j])
				if maxVal > minVal {
					dp[i][j][0] = maxVal
					dp[i][j][1] = minVal
				} else {
					dp[i][j][0] = minVal
					dp[i][j][1] = maxVal
				}
			} else if grid[i][j] > 0 {
				a := dp[i-1][j][0]
				b := dp[i][j-1][0]
				maxVal := a
				if b > a {
					maxVal = b
				}
				c := dp[i-1][j][1]
				d := dp[i][j-1][1]
				minVal := c
				if d < c {
					minVal = d
				}
				maxVal *= int64(grid[i][j])
				minVal *= int64(grid[i][j])
				if maxVal > minVal {
					dp[i][j][0] = maxVal
					dp[i][j][1] = minVal
				} else {
					dp[i][j][0] = minVal
					dp[i][j][1] = maxVal
				}
			} else if grid[i][j] < 0 {
				a := dp[i-1][j][1]
				b := dp[i][j-1][1]
				maxVal := a
				if b < a {
					maxVal = b
				}
				c := dp[i-1][j][0]
				d := dp[i][j-1][0]
				minVal := c
				if d > c {
					minVal = d
				}
				maxVal *= int64(grid[i][j])
				minVal *= int64(grid[i][j])
				if maxVal > minVal {
					dp[i][j][0] = maxVal
					dp[i][j][1] = minVal
				} else {
					dp[i][j][0] = minVal
					dp[i][j][1] = maxVal
				}
			} else {
				dp[i][j][0] = 0
				dp[i][j][1] = 0
			}
		}
	}

	val := dp[m-1][n-1][0]
	if dp[m-1][n-1][1] > val {
		val = dp[m-1][n-1][1]
	}
	if val < 0 {
		return -1
	}
	return int(val % MOD)
}
// @lc code=end

