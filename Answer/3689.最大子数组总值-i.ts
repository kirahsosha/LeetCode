/*
 * @lc app=leetcode.cn id=3689 lang=typescript
 *
 * [3689] 最大子数组总值 I
 */

// @lc code=start
function maxTotalValue(nums: number[], k: number): number {
  let min = nums[0];
  let max = nums[0];
  for (let i = 1; i < nums.length; i++) {
    if (nums[i] < min) {
      min = nums[i];
    }
    if (nums[i] > max) {
      max = nums[i];
    }
  }
  return (max - min) * k;
}
// @lc code=end
