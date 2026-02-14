/*
 * @lc app=leetcode.cn id=799 lang=golang
 *
 * [799] 香槟塔
 */

// @lc code=start
func champagneTower(poured int, query_row int, query_glass int) float64 {
    var getHalf func(float64) float64
	getHalf = func(num float64) float64 {
		if num <= 1 {
			return 0
		}
		return (num - 1) / 2
	}

	// dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
	dp := make([][]float64, query_row + 1)
    for i := 0; i <= query_row; i++ {
		dp[i] = make([]float64, i + 1)
        if i == 0 {
			dp[i][0] = float64(poured)
		} else {
			dp[i][0] = getHalf(dp[i - 1][0])
            for j := 1; j < i; j++ {
				dp[i][j] = getHalf(dp[i - 1][j - 1]) + getHalf(dp[i - 1][j])
			}
            dp[i][i] = getHalf(dp[i - 1][i - 1])
		}
	}
	if(dp[query_row][query_glass] >= 1) {
		return 1
	}
	return dp[query_row][query_glass]
}
// @lc code=end

