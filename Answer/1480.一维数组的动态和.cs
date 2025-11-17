/*
 * @lc app=leetcode.cn id=1480 lang=csharp
 *
 * [1480] 一维数组的动态和
 */

// @lc code=start
public class Solution {
    public int[] RunningSum(int[] nums) {
        for (var i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
        }
        return nums;
    }
}
// @lc code=end

