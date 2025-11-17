/*
 * @lc app=leetcode.cn id=343 lang=csharp
 *
 * [343] 整数拆分
 */

// @lc code=start
public class Solution {
    //状态转移方程: dp[n] = Max(dp[1] * (n - 1), dp[2] * (n - 2), ..., dp[n - 2] * 2, dp[n - 1])
    public int IntegerBreak(int n) {
        if(n <= 3) return n - 1;
        int[] dp = new int[n + 1];
        dp[1] = 1;
        for(int i = 2; i <= n; i++)
        {
            dp[i] = i;
            for(int j = 1; j < i; j++)
            {
                dp[i] = Math.Max(dp[i], dp[j] * (i - j));
            }
        }
        return dp[n];
    }
}
// @lc code=end

