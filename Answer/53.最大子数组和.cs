/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子数组和
 */

// @lc code=start
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int sub = 0, max = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > sub + nums[i])
            {
                sub = nums[i];
            }
            else
            {
                sub += nums[i];
            }
            if (sub > max)
            {
                max = sub;
            }
        }
        return max;
    }
}
// @lc code=end

