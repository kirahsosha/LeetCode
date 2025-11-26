#
# @lc app=leetcode.cn id=2435 lang=python3
#
# [2435] 矩阵中和能被 K 整除的路径
#

# @lc code=start
class Solution:
    def numberOfPaths(self, grid: List[List[int]], k: int) -> int:
        m = len(grid)
        n = len(grid[0])
        dpOld = []
        dpNew = []
        MOD = 1000000007

        for i in range(m):
            if i != 0:
                dpOld = dpNew
            dpNew = [[0] * k for _ in range(n)]
            for j in range(n):
                if i == 0 and j == 0:
                    x = grid[0][0] % k
                    dpNew[0][x] = 1
                if j != 0:
                    for x in range(k):
                        if dpNew[j - 1][x] == 0:
                            continue
                        y = (x + grid[i][j]) % k
                        dpNew[j][y] = (dpNew[j][y] + dpNew[j - 1][x]) % MOD
                if i != 0:
                    for x in range(k):
                        if dpOld[j][x] == 0:
                            continue
                        y = (x + grid[i][j]) % k
                        dpNew[j][y] = (dpNew[j][y] + dpOld[j][x]) % MOD
        return dpNew[n - 1][0]
        
# @lc code=end

