#
# @lc app=leetcode.cn id=799 lang=python3
#
# [799] 香槟塔
#

# @lc code=start
class Solution:
    def champagneTower(self, poured: int, query_row: int, query_glass: int) -> float:
        def getHalf(self, num: float) -> float:
            if num <= 1:
                return 0
            return (num - 1) / 2

        # dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
        dp = []
        for i in range (0, query_row+1):
            dp.append([])
            if i == 0:
                dp[i].append(poured)
            else:
                dp[i].append(getHalf(self,dp[i - 1][0]))
                for j in range (1, i):
                    dp[i].append(getHalf(self,dp[i - 1][j - 1]) + getHalf(self,dp[i - 1][j]))
                dp[i].append(getHalf(self,dp[i - 1][i - 1]))
        return 1 if dp[query_row][query_glass] >= 1 else dp[query_row][query_glass]
# @lc code=end

