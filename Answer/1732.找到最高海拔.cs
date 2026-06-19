/*
 * @lc app=leetcode.cn id=1732 lang=csharp
 *
 * [1732] 找到最高海拔
 */

// @lc code=start
public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int cur = 0;
        foreach (int g in gain)
        {
            cur += g;
            if (cur > max) max = cur;
        }
        return max;
    }
}
// @lc code=end
