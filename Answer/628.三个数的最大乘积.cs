/*
 * @lc app=leetcode.cn id=628 lang=csharp
 *
 * [628] 三个数的最大乘积
 */

// @lc code=start
public class Solution
{
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;
        return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
    }
}
// @lc code=end

