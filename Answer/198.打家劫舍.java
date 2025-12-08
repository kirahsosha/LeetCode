/*
 * @lc app=leetcode.cn id=198 lang=java
 *
 * [198] 打家劫舍
 */

// @lc code=start
class Solution {

    public int rob(int[] nums) {
        //dp[i] = max(dp[i-1], dp[i-2] + num[i])
        //因为在计算dp[i]的时候只需要使用到dp[i - 1]和dp[i - 2], 所以将数组优化为两个int
        int n = nums.length;
        if (n == 0) {
            return 0;
        }
        if (n == 1) {
            return nums[0];
        }
        if (n == 2) {
            return Math.max(nums[0], nums[1]);
        }
        int dp1, dp2;
        dp1 = nums[0];
        dp2 = Math.max(nums[0], nums[1]);
        for (int i = 2; i < n; i++) {
            int sum = Math.max(dp1 + nums[i], dp2);
            dp1 = dp2;
            dp2 = sum;
        }
        return Math.max(dp1, dp2);
    }
}
// @lc code=end

