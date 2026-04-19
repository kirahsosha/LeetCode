/*
 * @lc app=leetcode.cn id=1855 lang=javascript
 *
 * [1855] 下标对中的最大距离
 */

// @lc code=start
/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var maxDistance = function(nums1, nums2) {
    let i = 0, ans = 0;
    for (let j = 0; j < nums2.length; j++) {
        while (i < nums1.length && nums1[i] > nums2[j]) {
            i++;
        }
        if (i === nums1.length) {
            break;
        }
        ans = Math.max(ans, j - i);
    }
    return ans;
};
// @lc code=end
