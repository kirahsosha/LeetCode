/*
 * @lc app=leetcode.cn id=2574 lang=csharp
 *
 * [2574] 左右元素和的差值
 */

// @lc code=start
public class Solution {
    public int[] LeftRightDifference(int[] nums) {
        int total = 0;
        foreach (int v in nums) {
            total += v;
        }

        int leftSum = 0;
        int[] ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            int diff = 2 * leftSum + nums[i] - total;
            ans[i] = diff < 0 ? -diff : diff;
            leftSum += nums[i];
        }
        return ans;
    }
}
// @lc code=end
