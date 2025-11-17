/*
 * @lc app=leetcode.cn id=1039 lang=csharp
 *
 * [1039] 多边形三角剖分的最低得分
 */

// @lc code=start
public class Solution
{
    const int INFINITY = int.MaxValue / 2;

    public int MinScoreTriangulation(int[] values)
    {
        int n = values.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
        }
        for (int subLength = 3; subLength <= n; subLength++)
        {
            for (int i = 0, j = subLength - 1; j < n; i++, j++)
            {
                int minScore = INFINITY;
                for (int k = i + 1; k < j; k++)
                {
                    int score = dp[i][k] + dp[k][j] + values[i] * values[k] * values[j];
                    minScore = Math.Min(minScore, score);
                }
                dp[i][j] = minScore;
            }
        }
        return dp[0][n - 1];
    }
}

// @lc code=end

//105
//60
//140
//84