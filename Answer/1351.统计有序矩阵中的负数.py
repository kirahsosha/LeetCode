#
# @lc app=leetcode.cn id=1351 lang=python3
#
# [1351] 统计有序矩阵中的负数
#

# @lc code=start
from typing import List


class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        m = len(grid)
        n = len(grid[0])
        ans = 0
        j = 0
        for i in range(m - 1, -1, -1):
            while j < n:
                if grid[i][j] < 0:
                    ans += n - j
                    break
                j += 1
        return ans
        
# @lc code=end

