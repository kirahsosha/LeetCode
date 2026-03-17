#
# @lc app=leetcode.cn id=3070 lang=python3
#
# [3070] 元素和小于等于 k 的子矩阵的数目
#

# @lc code=start
from typing import List


class Solution:
    def countSubmatrices(self, grid: List[List[int]], k: int) -> int:
        m = len(grid)
        n = len(grid[0])
        pre = [0] * n
        res = 0
        for i in range(0, m):
            sum = 0
            for j in range(0, n):
                pre[j] += grid[i][j]
                sum += pre[j]
                if sum <= k:
                    res += 1
                else:
                    n = j
                    break
        return res
        
# @lc code=end

