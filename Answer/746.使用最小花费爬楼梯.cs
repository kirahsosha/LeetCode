/*
 * @lc app=leetcode.cn id=746 lang=csharp
 *
 * [746] 使用最小花费爬楼梯
 */

// @lc code=start
public class Solution {
    //状态转移方程 dp[n] = min(dp[n-1], dp[n-2]) + cost[n]
    public int MinCostClimbingStairs(int[] cost) {
        int len = cost.Length;
        if(len == 2) return Math.Min(cost[0], cost[1]);
        int[] dp = new int[len];
        dp[0] = cost[0];
        dp[1] = cost[1];
        for(int i = 2; i < len; i++)
        {
            dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
        }
        return Math.Min(dp[len - 2], dp[len - 1]);
    }
}
// @lc code=end

