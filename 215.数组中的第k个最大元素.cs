/*
 * @lc app=leetcode.cn id=215 lang=csharp
 *
 * [215] 数组中的第K个最大元素
 */

// @lc code=start
public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        var s = nums.OrderByDescending(p => p).ToList();
        return s[k - 1];
    }
}
// @lc code=end

