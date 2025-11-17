/*
 * @lc app=leetcode.cn id=75 lang=csharp
 *
 * [75] 颜色分类
 */

// @lc code=start
public class Solution
{
    public void SortColors(int[] nums)
    {
        if (nums.Length == 1) return;
        int low = 0, mid = 0, high = nums.Length - 1;
        while (mid <= high)
        {
            while (low < nums.Length && nums[low] == 0)
            {
                low++;
            }

            while (high > 0 && nums[high] == 2)
            {
                high--;
            }
            if (mid < low) mid = low;
            if (mid > high) break;
            if (mid < nums.Length && nums[mid] == 0)
            {
                //var temp = nums[low];
                //nums[low] = nums[mid];
                //nums[mid] = temp;
                (nums[low], nums[mid]) = (nums[mid], nums[low]);
                low++;
            }
            else if (mid < nums.Length && nums[mid] == 2)
            {
                //var temp = nums[high];
                //nums[high] = nums[mid];
                //nums[mid] = temp;
                (nums[high], nums[mid]) = (nums[mid], nums[high]);
                high--;
            }
            else
            {
                mid++;
            }
        }
    }
}
// @lc code=end

