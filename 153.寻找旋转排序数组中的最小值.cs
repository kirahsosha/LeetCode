/*
 * @lc app=leetcode.cn id=153 lang=csharp
 *
 * [153] 寻找旋转排序数组中的最小值
 */

// @lc code=start
public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Min(nums[0], nums[1]);
        int left = 0, right = nums.Length - 1;
        int mid = (left + right) / 2;
        if (nums[left] < nums[right]) return nums[left];
        while (left < right)
        {
            if (nums[mid] < nums[mid - 1])
            {
                break;
            }
            else if (nums[mid] > nums[left])
            {
                left = mid;
            }
            else if (nums[mid] < nums[right])
            {
                right = mid;
            }
            else if (nums[left] < nums[left + 1])
            {
                left++;
            }
            else if (nums[right] > nums[right - 1])
            {
                right--;
            }
            else if (right == left + 1)
            {
                mid = nums[left] < nums[right] ? left : right;
                break;
            }
            else if (right == left)
            {
                mid = left;
                break;
            }
            mid = (left + right) / 2;
        }
        return nums[mid];
    }
}
// @lc code=end

