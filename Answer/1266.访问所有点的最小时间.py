#
# @lc app=leetcode.cn id=1266 lang=python3
#
# [1266] 访问所有点的最小时间
#

# @lc code=start
from typing import List


class Solution:
    def minTimeToVisitAllPoints(self, points: List[List[int]]) -> int:
        n = len(points)
        if n == 1:
            return 0
        res = 0
        x1 = points[0][0]
        y1 = points[0][1]
        for i in range(1, n):
            x = points[i][0]
            y = points[i][1]
            res += max(abs(x - x1), abs(y - y1))
            x1 = x
            y1 = y
        return res
        
# @lc code=end

