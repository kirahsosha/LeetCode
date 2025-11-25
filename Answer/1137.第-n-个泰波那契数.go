/*
 * @lc app=leetcode.cn id=1137 lang=golang
 *
 * [1137] 第 N 个泰波那契数
 */

// @lc code=start
func tribonacci(n int) int {
    //dp[n] = dp[n-1] + dp[n-2] + dp[n-3]
	if n == 0 {
		return 0
	}
	if n == 1 {
		return 1
	}
	if n == 2 {
		return 1
	}
	dp := make([]int, 38)
	dp[0] = 0
	dp[1] = 1
	dp[2] = 1
	for i := 3; i <= n; i++ {
		dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3]
	}
	return dp[n]
}
// @lc code=end

