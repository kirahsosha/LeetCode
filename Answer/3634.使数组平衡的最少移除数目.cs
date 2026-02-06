/*
 * @lc app=leetcode.cn id=3634 lang=csharp
 *
 * [3634] 使数组平衡的最少移除数目
 */

// @lc code=start
public class Solution
{
    public int MinRemoval(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int length = n;
        int right = 0;

        for (int left = 0; left < n; left++)
        {
            while (right < n && nums[right] <= (long)nums[left] * k)
            {
                right++;
            }
            length = Math.Min(length, n - (right - left));
        }
        return length;
    }
}
// @lc code=end

