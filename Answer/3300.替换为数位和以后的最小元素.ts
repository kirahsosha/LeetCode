/*
 * @lc app=leetcode.cn id=3300 lang=typescript
 *
 * [3300] 替换为数位和以后的最小元素
 */

// @lc code=start
function minElement(nums: number[]): number {
  let ans = Number.MAX_SAFE_INTEGER;
  for (const num of nums) {
    let sum = 0;
    for (let x = num; x > 0; x = Math.floor(x / 10)) {
      sum += x % 10;
    }

    if (sum < ans) {
      ans = sum;
    }
  }

  return ans;
}
// @lc code=end
