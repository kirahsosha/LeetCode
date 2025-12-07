#
# @lc app=leetcode.cn id=1523 lang=python3
#
# [1523] 在区间范围内统计奇数数目
#

# @lc code=start
class Solution:
    def countOdds(self, low: int, high: int) -> int:
        interval = high - low + 1
        if interval % 2 == 0:
            return interval // 2
        elif low % 2 == 0:
            return interval // 2
        else:
            return interval // 2 + 1
        
# @lc code=end

