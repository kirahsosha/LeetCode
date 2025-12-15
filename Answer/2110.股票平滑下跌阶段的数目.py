#
# @lc app=leetcode.cn id=2110 lang=python3
#
# [2110] 股票平滑下跌阶段的数目
#

# @lc code=start
class Solution:
    def getDescentPeriods(self, prices: List[int]) -> int:
        res = 0
        last = 0
        current = 0
        for price in prices:
            if current == 0:
                current += 1
                last = price
            elif price == last - 1:
                current += 1
                last = price
            else:
                res += current * (current + 1) // 2
                current = 1
                last = price
        res += current * (current + 1) // 2
        return res
        
# @lc code=end

