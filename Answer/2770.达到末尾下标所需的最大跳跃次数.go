/*
 * @lc app=leetcode.cn id=2770 lang=golang
 *
 * [2770] 达到末尾下标所需的最大跳跃次数
 */

// @lc code=start
func maximumJumps(nums []int, target int) int {
	// dp[i] 表示达到下标 i 所需的最大跳跃次数
	n := len(nums)
	dp := make([]int, n)
	for i := range dp {
		dp[i] = -1
	}
	dp[0] = 0

	for i := 1; i < n; i++ {
		for j := 0; j < i; j++ {
			if d := nums[i] - nums[j]; d <= target && d >= -target && dp[j] != -1 {
				if dp[j]+1 > dp[i] {
					dp[i] = dp[j] + 1
				}
			}
		}
	}

	return dp[n-1]
}
// @lc code=end

