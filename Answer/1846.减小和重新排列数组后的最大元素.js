/*
 * @lc app=leetcode.cn id=1846 lang=javascript
 *
 * [1846] 减小和重新排列数组后的最大元素
 */

// @lc code=start
/**
 * @param {number[]} arr
 * @return {number}
 */
var maximumElementAfterDecrementingAndRearranging = function (arr) {
  arr.sort((x1, x2) => x1 - x2);
  var prev = 0;
  for (var i = 0; i < arr.length; i++) {
    prev = Math.min(arr[i], prev + 1);
  }
  return prev;
};
// @lc code=end
