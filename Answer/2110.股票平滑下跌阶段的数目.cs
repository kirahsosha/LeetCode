/*
 * @lc app=leetcode.cn id=2110 lang=csharp
 *
 * [2110] 股票平滑下跌阶段的数目
 */

// @lc code=start
public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        long res = 0;
        int last = 0;
        long current = 0;
        foreach (var price in prices)
        {
            if (current == 0)
            {
                current++;
                last = price;
            }
            else if (price == last - 1)
            {
                current++;
                last = price;
            }
            else
            {
                res += current * (current + 1) / 2;
                current = 1;
                last = price;
            }
        }
        res += current * (current + 1) / 2;
        return res;
    }
}
// @lc code=end

