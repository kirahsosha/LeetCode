/*
 * @lc app=leetcode.cn id=1732 lang=javascript
 *
 * [1732] 找到最高海拔
 */

// @lc code=start
/**
 * @param {number[]} gain
 * @return {number}
 */
var largestAltitude = function (gain) {
  var max = 0;
  var cur = 0;
  for (var i = 0; i < gain.length; i++) {
    cur += gain[i];
    if (cur > max) max = cur;
  }
  return max;
};
// @lc code=end
