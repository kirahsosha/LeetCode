/*
 * @lc app=leetcode.cn id=976 lang=csharp
 *
 * [976] 三角形的最大周长
 */

// @lc code=start
public class Solution
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        for (int i = nums.Length - 1; i >= 2; --i)
        {
            if (nums[i - 2] + nums[i - 1] > nums[i])
            {
                return nums[i - 2] + nums[i - 1] + nums[i];
            }
        }
        return 0;
    }
}
// @lc code=end

