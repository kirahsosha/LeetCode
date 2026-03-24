#
# @lc app=leetcode.cn id=1886 lang=python3
#
# [1886] 判断矩阵经轮转后是否一致
#

# @lc code=start
from typing import List


class Solution:
    def findRotation(self, mat: List[List[int]], target: List[List[int]]) -> bool:
        n = len(mat)
        r1 = r2 = r3 = r4 = True
        for i in range(n):
            for j in range(n):
                if r1 and mat[i][j] != target[i][j]:
                    r1 = False
                if r2 and mat[i][j] != target[j][n - i - 1]:
                    r2 = False
                if r3 and mat[i][j] != target[n - i - 1][n - j - 1]:
                    r3 = False
                if r4 and mat[i][j] != target[n - j - 1][i]:
                    r4 = False
        return r1 or r2 or r3 or r4
# @lc code=end

