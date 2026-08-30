/*
 * @lc app=leetcode.cn id=2091 lang=csharp
 *
 * [2091] 从数组中移除最大值和最小值
 */

// @lc code=start
public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int n = nums.Length;
        if (n <= 2) return n;
        int minIndex = 0, maxIndex = 0;
        int min = int.MaxValue, max = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < min)
            {
                min = nums[i];
                minIndex = i;
            }
            if (nums[i] > max)
            {
                max = nums[i];
                maxIndex = i;
            }
        }
        int left = Math.Min(minIndex, maxIndex) + 1;
        int right = n - Math.Max(minIndex, maxIndex);
        int middle = Math.Abs(minIndex - maxIndex);
        return Math.Min(left + right, Math.Min(left + middle, right + middle));
    }
}
// @lc code=end

