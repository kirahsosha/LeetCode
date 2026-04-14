#
# @lc app=leetcode.cn id=2463 lang=python3
#
# [2463] 最小移动总距离
#

# @lc code=start
from typing import List


class Solution:
    def minimumTotalDistance(self, robot: List[int], factory: List[List[int]]) -> int:
        robot.sort()
        factory.sort(key=lambda x: x[0])

        n = len(robot)
        m = len(factory)
        INF = 10 ** 18
        dp = [[0] * (n + 1) for _ in range(m + 1)]
        for j in range(1, n + 1):
            dp[0][j] = INF

        for i in range(1, m + 1):
            pos, limit = factory[i - 1]
            for j in range(n + 1):
                dp[i][j] = dp[i - 1][j]
                total = 0
                for k in range(1, limit + 1):
                    if k > j:
                        break
                    total += abs(robot[j - k] - pos)
                    if dp[i - 1][j - k] != INF:
                        dp[i][j] = min(dp[i][j], dp[i - 1][j - k] + total)

        return dp[m][n]
# @lc code=end
