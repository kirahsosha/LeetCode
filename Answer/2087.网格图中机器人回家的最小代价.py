#
# @lc app=leetcode.cn id=2087 lang=python3
#
# [2087] 网格图中机器人回家的最小代价
#

# @lc code=start
from typing import List


class Solution:
    def minCost(self, startPos: List[int], homePos: List[int], rowCosts: List[int], colCosts: List[int]) -> int:
        sr, sc = startPos
        hr, hc = homePos
        cost = 0
        if sr < hr:
            for i in range(sr + 1, hr + 1):
                cost += rowCosts[i]
        else:
            for i in range(sr - 1, hr - 1, -1):
                cost += rowCosts[i]
        if sc < hc:
            for j in range(sc + 1, hc + 1):
                cost += colCosts[j]
        else:
            for j in range(sc - 1, hc - 1, -1):
                cost += colCosts[j]
        return cost
# @lc code=end

