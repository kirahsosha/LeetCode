/*
 * @lc app=leetcode.cn id=3010 lang=csharp
 *
 * [3010] 将数组分成最小总代价的子数组 I
 */

// @lc code=start
public class Solution
{
    public int MinimumCost(int[] nums)
    {
        var n1 = nums[0];
        nums = nums.Skip(1).OrderBy(x => x).ToArray();
        return n1 + nums[0] + nums[1];
    }
}
// @lc code=end

