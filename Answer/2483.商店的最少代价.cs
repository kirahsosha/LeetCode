/*
 * @lc app=leetcode.cn id=2483 lang=csharp
 *
 * [2483] 商店的最少代价
 */

// @lc code=start
public class Solution
{
    public int BestClosingTime(string customers)
    {
        var cost = 0;
        foreach (var customer in customers)
        {
            if (customer == 'Y')
            {
                cost++;
            }
        }
        var min = cost;
        var res = 0;
        for (int i = 0; i < customers.Length; i++)
        {
            if (customers[i] == 'Y')
            {
                cost--;
            }
            else
            {
                cost++;
            }
            if (cost < min)
            {
                min = cost;
                res = i + 1;
            }
        }
        return res;
    }
}
// @lc code=end

