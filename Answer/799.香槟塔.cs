/*
 * @lc app=leetcode.cn id=799 lang=csharp
 *
 * [799] 香槟塔
 */

// @lc code=start
public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        //dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
        var dp = new double[query_row + 1][];
        for (int i = 0; i <= query_row; i++)
        {
            dp[i] = new double[i + 1];
            if (i == 0)
            {
                dp[i][0] = poured;
            }
            else
            {
                dp[i][0] = GetHalf(dp[i - 1][0]);
                for (int j = 1; j < i; j++)
                {
                    dp[i][j] = GetHalf(dp[i - 1][j - 1]) + GetHalf(dp[i - 1][j]);
                }
                dp[i][i] = GetHalf(dp[i - 1][i - 1]);
            }
        }
        return dp[query_row][query_glass] >= 1 ? 1 : dp[query_row][query_glass];

        double GetHalf(double num)
        {
            if (num <= 1)
            {
                return 0;
            }
            return (num - 1) / 2;
        }
    }
}
// @lc code=end

