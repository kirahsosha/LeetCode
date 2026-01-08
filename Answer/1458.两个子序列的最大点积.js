/*
 * @lc app=leetcode.cn id=1458 lang=javascript
 *
 * [1458] 两个子序列的最大点积
 */

// @lc code=start
/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var maxDotProduct = function (nums1, nums2) {
    //i - nums1 index
    //j - nums2 index
    //dp[i][j] = max(dp[i-1][j-1], dp[i-1][j-1] + nums1[i] * nums2[j])
    let n1 = nums1.length;
    let n2 = nums2.length;
    let dp = Array.from({ length: n1 }, () => new Array(n2).fill(0));
    let max = -1000000;
    for (let i = 0; i < n1; i++) {
        for (let j = 0; j < n2; j++) {
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
                dp[i][j] = Math.max(dp[i][j - 1], dp[i - 1][j], dp[i - 1][j - 1], dp[i - 1][j - 1] + nums1[i] * nums2[j], nums1[i] * nums2[j]);
                max = Math.max(max, dp[i][j]);
            }
        }
    }
    return max;
};
// @lc code=end

