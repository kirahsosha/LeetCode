#
# @lc app=leetcode.cn id=2154 lang=python3
#
# [2154] 将找到的值乘以 2
#

# @lc code=start
from typing import List


class Solution:
    def findFinalValue(self, nums: List[int], original: int) -> int:
        m = set(nums)
        while original in m:
            original *= 2
        return original
        
# @lc code=end

