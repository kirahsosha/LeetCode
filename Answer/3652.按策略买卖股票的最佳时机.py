#
# @lc app=leetcode.cn id=3652 lang=python3
#
# [3652] 按策略买卖股票的最佳时机
#

# @lc code=start
from typing import List


class Solution:
    def maxProfit(self, prices: List[int], strategy: List[int], k: int) -> int:
        res = 0
        n = len(prices)
        for i in range(n):
            res += prices[i] * strategy[i]
        t = k // 2
        max_p = res
        for i in range(t):
            res -= prices[i] * strategy[i]
        for i in range(t, k):
            res += prices[i] * (1 - strategy[i])
        max_p = max(max_p, res)
        for i in range(n - k):
            res += prices[i] * strategy[i]
            res -= prices[i + t]
            res += prices[i + k] * (1 - strategy[i + k])
            max_p = max(max_p, res)
        return max_p
        
# @lc code=end

