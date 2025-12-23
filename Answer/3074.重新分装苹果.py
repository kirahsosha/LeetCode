#
# @lc app=leetcode.cn id=3074 lang=python3
#
# [3074] 重新分装苹果
#

# @lc code=start
from typing import List


class Solution:
    def minimumBoxes(self, apple: List[int], capacity: List[int]) -> int:
        apples = 0
        for appleCount in apple:
            apples += appleCount
        capacity.sort()
        capacity.reverse()
        res = 0
        for cap in capacity:
            apples -= cap
            res += 1
            if apples <= 0:
                break
        return res
        
# @lc code=end

