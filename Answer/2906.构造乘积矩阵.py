#
# @lc app=leetcode.cn id=2906 lang=python3
#
# [2906] 构造乘积矩阵
#

# @lc code=start
from typing import List


class Solution:
    def constructProductMatrix(self, grid: List[List[int]]) -> List[List[int]]:
        mod = 12345
        n = len(grid)
        m = len(grid[0])
        left = [0] * (n * m + 1)
        right = [0] * (n * m + 1)
        left[0] = 1
        right[-1] = 1
        for i in range(n):
            for j in range(m):
                left[i * m + j + 1] = left[i * m + j] * grid[i][j] % mod

        for i in range(n - 1, -1, -1):
            for j in range(m - 1, -1, -1):
                right[i * m + j] = right[i * m + j + 1] * grid[i][j] % mod

        p = [[0] * m for _ in range(n)]
        for i in range(n):
            for j in range(m):
                p[i][j] = (left[i * m + j] * right[i * m + j + 1]) % mod
        return p
# @lc code=end

