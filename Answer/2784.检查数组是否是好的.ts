/*
 * @lc app=leetcode.cn id=2784 lang=typescript
 *
 * [2784] 检查数组是否是好的
 */

// @lc code=start
function isGood(nums: number[]): boolean {
  const n = nums.length - 1;
  if (n === 0) {
    return false;
  }

  const cnt = new Array(n).fill(0);
  for (const num of nums) {
    if (num > n || num <= 0) {
      return false;
    }
    if (num !== n && cnt[num - 1] === 1) {
      return false;
    }
    if (num === n && cnt[num - 1] > 1) {
      return false;
    }
    cnt[num - 1]++;
  }
  return true;
}
// @lc code=end
