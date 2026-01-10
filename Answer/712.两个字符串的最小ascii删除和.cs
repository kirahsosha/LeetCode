/*
 * @lc app=leetcode.cn id=712 lang=csharp
 *
 * [712] 两个字符串的最小ASCII删除和
 */

// @lc code=start
public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        var m = s1.Length;
        var n = s2.Length;
        var dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
        }
        for (int j = 1; j <= n; j++)
        {
            dp[0, j] = dp[0, j - 1] + s2[j - 1];
        }
        for (int i = 1; i <= m; i++)
        {
            int char1 = s1[i - 1];
            for (int j = 1; j <= n; j++)
            {
                int char2 = s2[j - 1];
                if (char1 == char2)
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(dp[i - 1, j] + char1, dp[i, j - 1] + char2);
                }
            }
        }
        return dp[m, n];
    }
}
// @lc code=end

