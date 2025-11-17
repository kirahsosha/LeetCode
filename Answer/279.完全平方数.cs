/*
 * @lc app=leetcode.cn id=279 lang=csharp
 *
 * [279] 完全平方数
 */

// @lc code=start
public class Solution
{
    public int NumSquares(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = n;
            for (int j = 1; j * j <= i; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
            }
        }
        return dp[n];
    }
}
// @lc code=end

