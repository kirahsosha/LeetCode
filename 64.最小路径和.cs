/*
 * @lc app=leetcode.cn id=64 lang=csharp
 *
 * [64] 最小路径和
 */

// @lc code=start
public class Solution {
    //dp[m][n] - 左上角到当前点的最小路径和
    //预处理 dp[m][0] = dp[m - 1][0] + grid[m][0], dp[0][n] = dp[0][n - 1] + grid[0][n]
    //状态转移方程 dp[m][n] = min(dp[m - 1][n], dp[m][n - 1]) + grid[m][n]
    public int MinPathSum(int[][] grid) {
        if(grid.Length == 0 || grid[0].Length == 0) return 0;
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] dp = new int[m][];
        for(int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }
        dp[0][0] = grid[0][0];
        for(int i = 1; i < m; i++)
        {
            dp[i][0] = dp[i - 1][0] + grid[i][0];
        }
        for(int j = 1; j < n; j++)
        {
            dp[0][j] = dp[0][j - 1] + grid[0][j];
        }
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + grid[i][j];
            }
        }
        return dp[m - 1][n - 1];
    }
}
// @lc code=end

