#
# @lc app=leetcode.cn id=509 lang=python3
#
# [509] 斐波那契数
#

# @lc code=start
class Solution:
    def fib(self, n: int) -> int:
        #dp[n] = dp[n - 1] + dp[n - 2]
        if n == 0:
            return 0
        if n == 1:
            return 1
        dp = []
        dp.append(0)
        dp.append(1)
        for i in range(2, n + 1):
            dp.append(dp[i - 1] + dp[i - 2])
        return dp[n]

# @lc code=end

