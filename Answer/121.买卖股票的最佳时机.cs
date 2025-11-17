/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length < 2) return 0;
        int min = prices[0], max = prices[0], maxp = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < min)
            {
                maxp = Math.Max(maxp, max - min);
                min = prices[i];
                max = 0;
            }
            else if (prices[i] > max)
            {
                max = prices[i];
            }
        }
        maxp = Math.Max(maxp, max - min);
        return maxp;
    }
}
// @lc code=end

