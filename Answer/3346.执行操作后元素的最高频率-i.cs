/*
 * @lc app=leetcode.cn id=3346 lang=csharp
 *
 * [3346] 执行操作后元素的最高频率 I
 */

// @lc code=start
public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        Array.Sort(nums);
        int maximumFrequencyInNums = MaxFrequencyInNums(nums, k, numOperations);
        if (maximumFrequencyInNums >= numOperations)
        {
            return maximumFrequencyInNums;
        }
        int maximumFrequencyNotInNums = MaxFrequencyNotInNums(nums, k, numOperations);
        return Math.Max(maximumFrequencyInNums, maximumFrequencyNotInNums);
    }

    public int MaxFrequencyInNums(int[] nums, int k, int numOperations)
    {
        int maximumFrequency = 0;
        int n = nums.Length;
        int start = 0, end = 0;
        int targetIndex = 0;
        int targetFrequency = 0;
        while (targetIndex < n)
        {
            int target = nums[targetIndex];
            targetFrequency = 1;
            while (targetIndex + 1 < n && nums[targetIndex + 1] == target)
            {
                targetIndex++;
                targetFrequency++;
            }
            while (nums[start] < target - k)
            {
                start++;
            }
            while (end + 1 < n && nums[end + 1] <= target + k)
            {
                end++;
            }
            maximumFrequency = Math.Max(maximumFrequency, Math.Min(end - start + 1, targetFrequency + numOperations));
            targetIndex++;
        }
        return maximumFrequency;
    }

    public int MaxFrequencyNotInNums(int[] nums, int k, int numOperations)
    {
        int maximumFrequency = 0;
        int n = nums.Length;
        int start = 0, end = 0;
        while (end < n)
        {
            while (nums[end] - nums[start] > 2 * k)
            {
                start++;
            }
            maximumFrequency = Math.Max(maximumFrequency, Math.Min(end - start + 1, numOperations));
            end++;
        }
        return maximumFrequency;
    }
}
// @lc code=end

