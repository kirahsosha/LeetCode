'''
 * @lc app=leetcode.cn id=2144 lang=python3
 *
 * [2144] 打折购买糖果的最小开销
'''

# @lc code=start
from typing import List


class Solution:
    def minimumCost(self, cost: List[int]) -> int:
        cost.sort()
        total_cost = 0
        for i in range(len(cost) - 1, -1, -3):
            total_cost += cost[i]
            if i > 0:
                total_cost += cost[i - 1]
        return total_cost
# @lc code=end