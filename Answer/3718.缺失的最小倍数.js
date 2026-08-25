/*
 * @lc app=leetcode.cn id=3718 lang=javascript
 *
 * [3718] 缺失的最小倍数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var missingMultiple = function (nums, k) {
  const set = new Set(nums);
  let multiple = k;
  while (set.has(multiple)) multiple += k;
  return multiple;
};
// @lc code=end
