/*
 * @lc app=leetcode.cn id=3718 lang=typescript
 *
 * [3718] 缺失的最小倍数
 */

// @lc code=start
function missingMultiple(nums: number[], k: number): number {
  const set = new Set<number>(nums);
  let multiple = k;
  while (set.has(multiple)) {
    multiple += k;
  }
  return multiple;
}
// @lc code=end
