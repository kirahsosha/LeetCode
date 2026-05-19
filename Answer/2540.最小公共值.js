/*
 * @lc app=leetcode.cn id=2540 lang=javascript
 *
 * [2540] 最小公共值
 */

// @lc code=start
/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var getCommon = function (nums1, nums2) {
  let i = 0;
  let j = 0;
  while (i < nums1.length && j < nums2.length) {
    if (nums1[i] === nums2[j]) {
      return nums1[i];
    }
    if (nums1[i] < nums2[j]) {
      i++;
    } else {
      j++;
    }
  }

  return -1;
};
// @lc code=end
