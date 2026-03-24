#
# @lc app=leetcode.cn id=3643 lang=python3
#
# [3643] 垂直翻转子矩阵
#

# @lc code=start
from typing import List


class Solution:
    def reverseSubmatrix(self, grid: List[List[int]], x: int, y: int, k: int) -> List[List[int]]:
        for i in range(x, x + k // 2):
            t = 2 * x + k - i - 1
            for j in range(y, y + k):
                temp = grid[i][j]
                grid[i][j] = grid[t][j]
                grid[t][j] = temp
        return grid
# @lc code=end

