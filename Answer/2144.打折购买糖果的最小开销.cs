/*
 * @lc app=leetcode.cn id=2144 lang=csharp
 *
 * [2144] 打折购买糖果的最小开销
 */

// @lc code=start
public class Solution
{
    public int MinimumCost(int[] cost)
    {
        Array.Sort(cost);
        int totalCost = 0;
        for (int i = cost.Length - 1; i >= 0; i -= 3)
        {
            totalCost += cost[i];
            if (i > 0)
            {
                totalCost += cost[i - 1];
            }
        }
        return totalCost;
    }
}
// @lc code=end