#
# @lc app=leetcode.cn id=3546 lang=python3
#
# [3546] 等和矩阵分割 I
#

# @lc code=start
from typing import List


class Solution:
    def canPartitionGrid(self, grid: List[List[int]]) -> bool:
        m = len(grid)
        n = len(grid[0])
        if m == 1 and n == 1:
            return False
        ver = [0] * m
        hor = [0] * n
        total = 0
        for i in range(m):
            if i > 0:
                ver[i] = ver[i - 1]
            for j in range(n):
                ver[i] += grid[i][j]
                hor[j] += grid[i][j]
                if i == m - 1 and j > 0:
                    hor[j] += hor[j - 1]
                total += grid[i][j]
        if total % 2 != 0:
            return False
        half = total // 2
        if half in ver:
            return True
        if half in hor:
            return True
        return False
# @lc code=end

