/*
 * @lc app=leetcode.cn id=34 lang=csharp
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 */

// @lc code=start
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
        {
            int start = SearchStart(nums, target);
            if (start < 0)
            {
                return new int[] { -1, -1 };
            }
            int end = SearchEnd(nums, target);
            return new int[] { start, end };
        }

        public int SearchStart(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] >= target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low < nums.Length && nums[low] == target ? low : -1;
        }

        public int SearchEnd(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low + 1) / 2;
                if (nums[mid] <= target)
                {
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low < nums.Length && nums[low] == target ? low : -1;
        }
}
// @lc code=end

