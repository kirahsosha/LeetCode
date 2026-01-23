/*
 * @lc app=leetcode.cn id=1877 lang=csharp
 *
 * [1877] 数组中最大数对和的最小值
 */

// @lc code=start
public class Solution
{
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        var ans = 0;
        for (int i = 0; i < nums.Length / 2; i++)
        {
            ans = Math.Max(ans, nums[i] + nums[nums.Length - i - 1]);
        }
        return ans;
    }
}
// @lc code=end

