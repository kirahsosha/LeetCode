/*
 * @lc app=leetcode.cn id=154 lang=csharp
 *
 * [154] 寻找旋转排序数组中的最小值 II
 */

// @lc code=start
public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else if (nums[mid] < nums[right])
            {
                right = mid;
            }
            else
            {
                right--;
            }
        }
        return nums[left];
    }
}
// @lc code=end
