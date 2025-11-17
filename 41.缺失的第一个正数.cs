/*
 * @lc app=leetcode.cn id=41 lang=csharp
 *
 * [41] 缺失的第一个正数
 */

// @lc code=start
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;
        int min = n;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > n || nums[i] <= 0)
            {
                nums[i] = n + 1;
                continue;
            }
            min = Math.Min(min, nums[i]);
        }
        if (min > 1)
        {
            return 1;
        }
        for (int i = 0; i < n; i++)
        {
            int t = Math.Abs(nums[i]);
            if (t > n)
            {
                continue;
            }
            if (nums[t - 1] > 0)
            {
                nums[t - 1] = -nums[t - 1];
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
            {
                return i + 1;
            }
        }
        return n + 1;
    }
}
// @lc code=end

