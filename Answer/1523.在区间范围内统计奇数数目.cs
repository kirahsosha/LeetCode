/*
 * @lc app=leetcode.cn id=1523 lang=csharp
 *
 * [1523] 在区间范围内统计奇数数目
 */

// @lc code=start
public class Solution
{
    public int CountOdds(int low, int high)
    {
        var interval = high - low + 1;
        if (interval % 2 == 0)
        {
            return interval / 2;
        }
        else if (low % 2 == 0)
        {
            return interval / 2;
        }
        else
        {
            return interval / 2 + 1;
        }
    }
}
// @lc code=end

