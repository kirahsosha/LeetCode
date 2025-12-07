#
# @lc app=leetcode.cn id=746 lang=python3
#
# [746] 使用最小花费爬楼梯
#

# @lc code=start
class Solution:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        # dp[0] = cost[0]
        # dp[1] = cost[1]
        # dp[i] = min(dp[i-1], dp[i-2]) + cost[i]
        n = len(cost)
        if n == 2:
            return min(cost[0], cost[1])
        dp = []
        dp.append(cost[0])
        dp.append(cost[1])
        for i in range(2, n):
            dp.append(min(dp[i - 2], dp[i - 1]) + cost[i])
        return min(dp[n - 2], dp[n - 1])
        
# @lc code=end

