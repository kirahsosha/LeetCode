#
# @lc app=leetcode.cn id=1137 lang=python3
#
# [1137] 第 N 个泰波那契数
#

# @lc code=start
class Solution:
    def tribonacci(self, n: int) -> int:
        # dp[n] = dp[n-1] + dp[n-2] + dp[n-3]
        if n == 0:
            return 0
        if n == 1:
            return 1
        if n == 2:
            return 1
        dp = []
        dp.append(0)
        dp.append(1)
        dp.append(1)
        for i in range(3, n + 1):
            dp.append(dp[i - 1] + dp[i - 2] + dp[i - 3])
        return dp[n]
        
# @lc code=end

