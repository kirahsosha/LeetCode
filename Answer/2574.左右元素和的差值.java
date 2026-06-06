/*
 * @lc app=leetcode.cn id=2574 lang=java
 *
 * [2574] 左右元素和的差值
 */

// @lc code=start
class Solution {
    public int[] leftRightDifference(int[] nums) {
        int total = 0;
        for (int v : nums) {
            total += v;
        }

        int leftSum = 0;
        int[] ans = new int[nums.length];
        for (int i = 0; i < nums.length; i++) {
            int diff = 2 * leftSum + nums[i] - total;
            ans[i] = diff < 0 ? -diff : diff;
            leftSum += nums[i];
        }
        return ans;
    }
}
// @lc code=end
