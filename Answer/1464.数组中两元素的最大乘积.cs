/*
 * @lc app=leetcode.cn id=1464 lang=csharp
 *
 * [1464] 数组中两元素的最大乘积
 */

// @lc code=start
public class Solution
{
    public int MaxProduct(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;
        return (nums[n - 1] - 1) * (nums[n - 2] - 1);
    }
}
// @lc code=end

