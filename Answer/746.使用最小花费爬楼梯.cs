/*
 * @lc app=leetcode.cn id=746 lang=csharp
 *
 * [746] 使用最小花费爬楼梯
 */

// @lc code=start
public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        //dp[0] = cost[0]
        //dp[1] = cost[1]
        //dp[i] = min(dp[i-1], dp[i-2]) + cost[i]
        var n = cost.Length;
        if (n == 2) return Math.Min(cost[0], cost[1]);
        var dp = new int[n];
        dp[0] = cost[0];
        dp[1] = cost[1];
        for (var i = 2; i < n; i++)
        {
            dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
        }
        return Math.Min(dp[n - 2], dp[n - 1]);
    }
}
// @lc code=end

