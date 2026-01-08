/*
 * @lc app=leetcode.cn id=1458 lang=java
 *
 * [1458] 两个子序列的最大点积
 */

// @lc code=start
class Solution {

    public int maxDotProduct(int[] nums1, int[] nums2) {
        //i - nums1 index
        //j - nums2 index
        //dp[i][j] = max(dp[i-1][j-1], dp[i-1][j-1] + nums1[i] * nums2[j])
        var n1 = nums1.length;
        var n2 = nums2.length;
        var dp = new int[n1][n2];
        var max = -1000000;
        for (var i = 0; i < n1; i++) {
            for (var j = 0; j < n2; j++) {
                if (i == 0 && j == 0) {
                    dp[0][0] = Math.max(-1000000, nums1[i] * nums2[j]);
                    max = Math.max(max, dp[i][j]);
                } else if (i == 0) {
                    dp[0][j] = Math.max(dp[0][j - 1], nums1[i] * nums2[j]);
                    max = Math.max(max, dp[i][j]);
                } else if (j == 0) {
                    dp[i][0] = Math.max(dp[i - 1][0], nums1[i] * nums2[j]);
                    max = Math.max(max, dp[i][j]);
                } else {
                    dp[i][j] = Math.max(Math.max(dp[i][j - 1], dp[i - 1][j]), Math.max(dp[i - 1][j - 1], Math.max(dp[i - 1][j - 1] + nums1[i] * nums2[j], nums1[i] * nums2[j])));
                    max = Math.max(max, dp[i][j]);
                }
            }
        }
        return max;
    }
}
// @lc code=end

