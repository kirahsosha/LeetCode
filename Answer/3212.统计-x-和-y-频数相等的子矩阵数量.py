#
# @lc app=leetcode.cn id=3212 lang=python3
#
# [3212] 统计 X 和 Y 频数相等的子矩阵数量
#

# @lc code=start
from typing import List


class Solution:
    def numberOfSubmatrices(self, grid: List[List[str]]) -> int:
        m = len(grid)
        n = len(grid[0])
        cntX = [0] * n
        cntY = [0] * n
        res = 0
        for i in range(0, m):
            sumX = 0
            sumY = 0
            for j in range(0, n):
                cntX[j] += 1 if grid[i][j] == 'X' else 0
                cntY[j] += 1 if grid[i][j] == 'Y' else 0
                sumX += cntX[j]
                sumY += cntY[j]
                if sumX == sumY and sumX > 0:
                    res += 1
        return res
        
# @lc code=end

