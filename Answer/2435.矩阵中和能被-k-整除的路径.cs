/*
 * @lc app=leetcode.cn id=2435 lang=csharp
 *
 * [2435] 矩阵中和能被 K 整除的路径
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int NumberOfPaths(int[][] grid, int k)
    {
        //optimize：dpNew[j][x] = dpOld[j][x+grid[i][j]] + dpNew[j-1][x+grid[i][j]]
        var m = grid.Length;
        var n = grid[0].Length;
        var dpOld = new int[n][];
        var dpNew = new int[n][];

        for (int i = 0; i < m; i++)
        {
            if (i != 0)
            {
                dpOld = dpNew;
            }
            dpNew = new int[n][];
            for (int j = 0; j < n; j++)
            {
                dpNew[j] = new int[k];
                if (i == 0 && j == 0)
                {
                    var x = grid[0][0] % k;
                    dpNew[0][x] = 1;
                }
                if (j != 0)
                {
                    for (int x = 0; x < k; x++)
                    {
                        if (dpNew[j - 1][x] == 0) continue;
                        int y = (x + grid[i][j]) % k;
                        dpNew[j][y] = (dpNew[j][y] + dpNew[j - 1][x]) % MOD;
                    }
                }
                if (i != 0)
                {
                    for (int x = 0; x < k; x++)
                    {
                        if (dpOld[j][x] == 0) continue;
                        int y = (x + grid[i][j]) % k;
                        dpNew[j][y] = (dpNew[j][y] + dpOld[j][x]) % MOD;
                    }
                }
            }
        }
        return dpNew[n - 1][0];
    }
}
// @lc code=end

