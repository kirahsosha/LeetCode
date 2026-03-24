/*
 * @lc app=leetcode.cn id=1594 lang=csharp
 *
 * [1594] 矩阵的最大非负积
 */

// @lc code=start
public class Solution
{
    public const int MOD = 1000000007;
    public int MaxProductPath(int[][] grid)
    {
        //dp[i][j][2] - 0: max, 1: min
        var m = grid.Length;
        var n = grid[0].Length;
        var dp = new long[m, n, 2];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    dp[i, j, 0] = grid[i][j];
                    dp[i, j, 1] = grid[i][j];
                }
                else if (i == 0)
                {
                    var maxVal = dp[i, j - 1, 0] * grid[i][j];
                    var minVal = dp[i, j - 1, 1] * grid[i][j];
                    dp[i, j, 0] = Math.Max(maxVal, minVal);
                    dp[i, j, 1] = Math.Min(maxVal, minVal);
                }
                else if (j == 0)
                {
                    var maxVal = dp[i - 1, j, 0] * grid[i][j];
                    var minVal = dp[i - 1, j, 1] * grid[i][j];
                    dp[i, j, 0] = Math.Max(maxVal, minVal);
                    dp[i, j, 1] = Math.Min(maxVal, minVal);
                }
                else if (grid[i][j] > 0)
                {
                    var maxVal = Math.Max(dp[i - 1, j, 0], dp[i, j - 1, 0]) * grid[i][j];
                    var minVal = Math.Min(dp[i - 1, j, 1], dp[i, j - 1, 1]) * grid[i][j];
                    dp[i, j, 0] = Math.Max(maxVal, minVal);
                    dp[i, j, 1] = Math.Min(maxVal, minVal);
                }
                else if (grid[i][j] < 0)
                {
                    var maxVal = Math.Min(dp[i - 1, j, 1], dp[i, j - 1, 1]) * grid[i][j];
                    var minVal = Math.Max(dp[i - 1, j, 0], dp[i, j - 1, 0]) * grid[i][j];
                    dp[i, j, 0] = Math.Max(maxVal, minVal);
                    dp[i, j, 1] = Math.Min(maxVal, minVal);
                }
                else
                {
                    dp[i, j, 0] = 0;
                    dp[i, j, 1] = 0;
                }
            }
        }
        var val = Math.Max(dp[m - 1, n - 1, 0], dp[m - 1, n - 1, 1]);
        return val < 0 ? -1 : (int)(val % MOD);
    }
}
// @lc code=end

