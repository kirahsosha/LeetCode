/*
 * @lc app=leetcode.cn id=3689 lang=csharp
 *
 * [3689] 最大子数组总值 I
 */

// @lc code=start
public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        long min = nums[0];
        long max = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            long v = nums[i];
            if (v < min)
            {
                min = v;
            }
            if (v > max)
            {
                max = v;
            }
        }
        return (max - min) * k;
    }
}
// @lc code=end
