#
# @lc app=leetcode.cn id=840 lang=python3
#
# [840] 矩阵中的幻方
#

# @lc code=start
from typing import List


class Solution:
    def numMagicSquaresInside(self, grid: List[List[int]]) -> int:
        n = len(grid)
        m = len(grid[0])
        res = 0
        for i in range(n - 2):
            for j in range(m - 2):
                if isMagicSquare(self, grid, i, j):
                    res += 1
        return res
    
def isMagicSquare(self, grid: List[List[int]], x: int, y: int) -> bool:
    target = 15
    seen = set()
    for i in range(3):
        for j in range(3):
            val = grid[x + i][y + j];
            if val < 1 or val > 9 or val in seen:
                return False
            seen.add(val)
    for i in range(3):
        rowSum = 0
        colSum = 0
        for j in range(3):
            rowSum += grid[x + i][y + j]
            colSum += grid[x + j][y + i]
        if rowSum != target or colSum != target:
            return False
        diag1 = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2]
        diag2 = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y]
        if diag1 != target or diag2 != target:
            return False
    return True
        
# @lc code=end

