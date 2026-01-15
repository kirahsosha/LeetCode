#
# @lc app=leetcode.cn id=2943 lang=python3
#
# [2943] 最大化网格图中正方形空洞的面积
#

# @lc code=start
from typing import List


class Solution:
    def maximizeSquareHoleArea(self, n: int, m: int, hBars: List[int], vBars: List[int]) -> int:
        hBars.sort()
        hMax = 1
        left = 1
        right = 2
        for bar in hBars:
            if bar == right:
                right = bar + 1
            else:
                left = bar - 1
                right = bar + 1
            hMax = max(hMax, right - left)

        vBars.sort()
        vMax = 1
        left = 1
        right = 2
        for bar in vBars:
            if bar == right:
                right = bar + 1
            else:
                left = bar - 1
                right = bar + 1
            vMax = max(vMax, right - left);
        l = min(hMax, vMax)
        return l * l
        
# @lc code=end

