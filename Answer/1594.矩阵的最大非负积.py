#
# @lc app=leetcode.cn id=1594 lang=python3
#
# [1594] 矩阵的最大非负积
#

# @lc code=start
from typing import List


class Solution:
    def maxProductPath(self, grid: List[List[int]]) -> int:
        MOD = 1000000007
        m = len(grid)
        n = len(grid[0])
        dp = [[[0, 0] for _ in range(n)] for _ in range(m)]
        for i in range(m):
            for j in range(n):
                if i == 0 and j == 0:
                    dp[i][j][0] = grid[i][j]
                    dp[i][j][1] = grid[i][j]
                elif i == 0:
                    maxVal = dp[i][j - 1][0] * grid[i][j]
                    minVal = dp[i][j - 1][1] * grid[i][j]
                    dp[i][j][0] = max(maxVal, minVal)
                    dp[i][j][1] = min(maxVal, minVal)
                elif j == 0:
                    maxVal = dp[i - 1][j][0] * grid[i][j]
                    minVal = dp[i - 1][j][1] * grid[i][j]
                    dp[i][j][0] = max(maxVal, minVal)
                    dp[i][j][1] = min(maxVal, minVal)
                elif grid[i][j] > 0:
                    maxVal = max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j]
                    minVal = min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j]
                    dp[i][j][0] = max(maxVal, minVal)
                    dp[i][j][1] = min(maxVal, minVal)
                elif grid[i][j] < 0:
                    maxVal = min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j]
                    minVal = max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j]
                    dp[i][j][0] = max(maxVal, minVal)
                    dp[i][j][1] = min(maxVal, minVal)
                else:
                    dp[i][j][0] = 0
                    dp[i][j][1] = 0
        val = max(dp[m - 1][n - 1][0], dp[m - 1][n - 1][1])
        return -1 if val < 0 else val % MOD
# @lc code=end

