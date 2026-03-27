#
# @lc app=leetcode.cn id=2946 lang=python3
#
# [2946] 循环移位后的矩阵相似检查
#

# @lc code=start
from typing import List


class Solution:
    def areSimilar(self, mat: List[List[int]], k: int) -> bool:
        m = len(mat)
        n = len(mat[0])
        k %= n
        if k == 0:
            return True
        
        for i in range(m):
            row = mat[i]
            if i & 1 == 0:
                for j in range(n):
                    if row[j] != row[(j + k) % n]:
                        return False
            else:
                for j in range(n):
                    if row[j] != row[(j - k + n) % n]:
                        return False
        return True
# @lc code=end

