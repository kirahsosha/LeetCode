/*
 * @lc app=leetcode.cn id=1984 lang=csharp
 *
 * [1984] 学生分数的最小差值
 */

// @lc code=start
public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        if (k == 1) return 0;
        Array.Sort(nums);
        int ans = nums[k - 1] - nums[0];
        for (int i = 1; i <= nums.Length - k; i++)
        {
            ans = Math.Min(ans, nums[i + k - 1] - nums[i]);
        }
        return ans;
    }
}
// @lc code=end

