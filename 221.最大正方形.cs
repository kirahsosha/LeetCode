/*
 * @lc app=leetcode.cn id=221 lang=csharp
 *
 * [221] 最大正方形
 */

// @lc code=start
public class Solution {
    //使用二维数组记录到达当前位置时的最大正方形的边长
    //初始化
    //dp[i][0] = matrix[i][0]
    //dp[0][j] = matrix[0][j]
    //状态转移方程
    //dp[i][j] = 0 || min(dp[i - 1][j], dp[i][j - 1], dp[i - 1][j - 1]) + 1
    public int MaximalSquare(char[][] matrix) {
        if(matrix.Length == 0) return 0;
        if(matrix[0].Length == 0) return 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        int max = matrix[0][0];
        int[][] dp = new int[m][];
        for(int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }
        dp[0][0] = matrix[0][0] == '0' ? 0 : 1;
        max = dp[0][0];
        for(int i = 1; i < m; i++)
        {
            dp[i][0] = matrix[i][0] == '0' ? 0 : 1;
            max = Math.Max(max, dp[i][0]);
        }
        for(int j = 1; j < n; j++)
        {
            dp[0][j] = matrix[0][j] == '0' ? 0 : 1;
            max = Math.Max(max, dp[0][j]);
        }
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                if(matrix[i][j] == '1')
                {
                    dp[i][j] = Math.Min(dp[i - 1][j - 1],
                                   Math.Min(dp[i][j - 1], dp[i - 1][j])) + 1;
                }
                max = Math.Max(max, dp[i][j]);
            }
        }
        return max * max;
    }
}
// @lc code=end

