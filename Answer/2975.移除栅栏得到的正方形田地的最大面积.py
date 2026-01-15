#
# @lc app=leetcode.cn id=2975 lang=python3
#
# [2975] 移除栅栏得到的正方形田地的最大面积
#

# @lc code=start
from typing import List


class Solution:
    def maximizeSquareArea(self, m: int, n: int, hFences: List[int], vFences: List[int]) -> int:
        MOD = 1000000007
        hFences.sort()
        hLength = set()
        hLength.add(m - 1)
        for i in range(0, len(hFences)):
            hLength.add(hFences[i] - 1)
            hLength.add(m - hFences[i])
            for j in range(i + 1, len(hFences)):
                hLength.add(hFences[j] - hFences[i])

        vFences.sort()
        vLength = set()
        vLength.add(n - 1)
        for i in range(0, len(vFences)):
            vLength.add(vFences[i] - 1)
            vLength.add(n - vFences[i])
            for j in range(i + 1, len(vFences)):
                vLength.add(vFences[j] - vFences[i])

        res = 0
        for length in hLength:
            if length in vLength:
                res = max(res, length)

        if res == 0:
            return -1
        else:
            return res * res % MOD
        
# @lc code=end

