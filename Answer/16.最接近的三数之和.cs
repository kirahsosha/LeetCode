/*
 * @lc app=leetcode.cn id=16 lang=csharp
 *
 * [16] 最接近的三数之和
 */

// @lc code=start
public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        var ans = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                int currentSum = nums[i] + nums[left] + nums[right];
                if (Math.Abs(currentSum - target) < Math.Abs(ans - target))
                {
                    ans = currentSum;
                }
                if (currentSum < target)
                {
                    left++;
                }
                else if (currentSum > target)
                {
                    right--;
                }
                else
                {
                    return currentSum; // Found the exact match
                }
            }
        }
        return ans;
    }
}
// @lc code=end

