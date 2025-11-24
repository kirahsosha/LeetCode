/*
 * @lc app=leetcode.cn id=509 lang=csharp
 *
 * [509] 斐波那契数
 */

// @lc code=start
public class Solution
{
    public int Fib(int n)
    {
        //dp[n] = dp[n - 1] + dp[n - 2]
        if (n == 0) return 0;
        if (n == 1) return 1;

        var dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
}
// @lc code=end

