/*
 * @lc app=leetcode.cn id=2091 lang=javascript
 *
 * [2091] 从数组中移除最大值和最小值
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minimumDeletions = function (nums) {
  const n = nums.length;
  let minIndex = 0;
  let maxIndex = 0;
  for (let i = 1; i < n; i++) {
    if (nums[i] < nums[minIndex]) {
      minIndex = i;
    }
    if (nums[i] > nums[maxIndex]) {
      maxIndex = i;
    }
  }
  if (minIndex > maxIndex) {
    [minIndex, maxIndex] = [maxIndex, minIndex];
  }
  return Math.min(maxIndex + 1, n - minIndex, minIndex + 1 + n - maxIndex);
};
// @lc code=end
