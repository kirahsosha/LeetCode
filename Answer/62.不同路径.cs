/*
 * @lc app=leetcode.cn id=62 lang=csharp
 *
 * [62] 不同路径
 */

// @lc code=start
public class Solution {
    //dp[m][n] - 走到每个点的不同路径数
    //预处理 dp[m][0] = 1, dp[0][n] = 1

    public int UniquePaths(int m, int n) {
        if(m == 1 || n == 1) return 1;
        int[][] dp = new int[m][];
        for(int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
            dp[i][0] = 1;
        }
        for(int j = 1; j < n; j++)
        {
            dp[0][j] = 1;
        }
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
            }
        }
        return dp[m - 1][n - 1];
    }
}
// @lc code=end

