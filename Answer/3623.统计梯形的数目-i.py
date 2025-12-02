#
# @lc app=leetcode.cn id=3623 lang=python3
#
# [3623] 统计梯形的数目 I
#

# @lc code=start
from collections import defaultdict
from typing import List


class Solution:
    def countTrapezoids(self, points: List[List[int]]) -> int:
        MOD = 1000000007
        # key：纵坐标；value：线段数量
        dic = defaultdict(int)
        for point in points:
            y = point[1]
            dic[y] += 1
        res, side = 0, 0
        for point in dic.values():
            edge = point * (point - 1) // 2
            res = (res + edge * side) % MOD
            side = (side + edge) % MOD
        return res
        
# @lc code=end

