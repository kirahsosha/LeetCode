/*
 * @lc app=leetcode.cn id=2221 lang=csharp
 *
 * [2221] 数组的三角和
 */

// @lc code=start
public class Solution
{
    public int TriangularSum(int[] nums)
    {
        for (int i = nums.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                nums[j] = (nums[j] + nums[j + 1]) % 10;
            }
        }
        return nums[0];
    }
}
// @lc code=end
