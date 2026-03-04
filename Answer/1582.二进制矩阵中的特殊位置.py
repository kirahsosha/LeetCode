#
# @lc app=leetcode.cn id=1582 lang=python3
#
# [1582] 二进制矩阵中的特殊位置
#

# @lc code=start
from typing import List


class Solution:
    def numSpecial(self, mat: List[List[int]]) -> int:
        m = len(mat)
        n = len(mat[0])
        rows = [0] * m
        res = 0
        for i in range (0, m):
            first = -1
            for j in range (0, n):
                if mat[i][j] == 1:
                    rows[i] = j
                    if first == -1:
                        first = j
            if first == rows[i]:
                a = -1
                b = -1
                for j in range( 0, m):
                    if mat[j][first] == 1:
                        if a == -1:
                            a = j
                        else:
                            b = j
                            break
                if a != -1 and b == -1:
                    res+=1
        return res
        
# @lc code=end

