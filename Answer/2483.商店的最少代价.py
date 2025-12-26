#
# @lc app=leetcode.cn id=2483 lang=python3
#
# [2483] 商店的最少代价
#

# @lc code=start
class Solution:
    def bestClosingTime(self, customers: str) -> int:
        cost = 0
        for i in range(len(customers)):
            if customers[i] == 'Y':
                cost += 1
        minCost = cost
        res = 0
        for i in range(len(customers)):
            if customers[i] == 'Y':
                cost -= 1
            else:
                cost += 1
            if cost < minCost:
                minCost = cost
                res = i + 1
        return res
        
# @lc code=end

