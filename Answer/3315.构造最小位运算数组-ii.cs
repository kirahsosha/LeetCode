/*
 * @lc app=leetcode.cn id=3315 lang=csharp
 *
 * [3315] 构造最小位运算数组 II
 */

// @lc code=start
public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        var n = nums.Count;
        var ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            var value = nums[i];
            if (value == 2)
            {
                ans[i] = -1;
            }
            else
            {
                int t = ~value;
                int lowbit = t & -t;
                ans[i] = value ^ (lowbit >> 1);
            }
        }
        return ans;
    }
}
// @lc code=end

