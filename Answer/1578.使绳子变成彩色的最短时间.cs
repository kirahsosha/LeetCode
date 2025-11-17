/*
 * @lc app=leetcode.cn id=1578 lang=csharp
 *
 * [1578] 使绳子变成彩色的最短时间
 */

// @lc code=start
public class Solution
{
    public int MinCost(string colors, int[] neededTime)
    {
        if (neededTime.Length == 1) return 0;
        var index = 0;
        int res = 0;
        for (int i = 1; i < neededTime.Length; i++)
        {
            if (colors[index] == colors[i])
            {
                //Move Min
                if (neededTime[index] <= neededTime[i])
                {
                    res += neededTime[index];
                    index = i;
                }
                else
                {
                    res += neededTime[i];
                }
            }
            else
            {
                index = i;
            }
        }
        return res;
    }
}
// @lc code=end

