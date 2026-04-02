#
# @lc app=leetcode.cn id=3418 lang=python3
#
# [3418] 机器人可以获得的最大金币数
#

# @lc code=start
from typing import List


class Solution:
    def maximumAmount(self, coins: List[List[int]]) -> int:
        m, n = len(coins), len(coins[0])

        def solve(rows: int, cols: int, transposed: bool) -> int:
            neg_inf = -10**30
            dp0 = [neg_inf] * cols
            dp1 = [neg_inf] * cols
            dp2 = [neg_inf] * cols

            for r in range(rows):
                left0 = neg_inf
                left1 = neg_inf
                left2 = neg_inf
                for c in range(cols):
                    up0 = dp0[c]
                    up1 = dp1[c]
                    up2 = dp2[c]

                    if r == 0 and c == 0:
                        best0 = 0
                        best1 = 0
                        best2 = 0
                    else:
                        best0 = max(up0, left0)
                        best1 = max(up1, left1)
                        best2 = max(up2, left2)

                    coin = coins[c][r] if transposed else coins[r][c]
                    cur0 = best0 + coin
                    cur1 = max(best1 + coin, best0)
                    cur2 = max(best2 + coin, best1)

                    dp0[c] = cur0
                    dp1[c] = cur1
                    dp2[c] = cur2

                    left0 = cur0
                    left1 = cur1
                    left2 = cur2

            return max(dp0[-1], dp1[-1], dp2[-1])

        if n <= m:
            return solve(m, n, False)
        return solve(n, m, True)
# @lc code=end

