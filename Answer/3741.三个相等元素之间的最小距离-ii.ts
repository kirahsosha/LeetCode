/*
 * @lc app=leetcode.cn id=3741 lang=typescript
 *
 * [3741] 三个相等元素之间的最小距离 II
 */

// @lc code=start
function minimumDistance(nums: number[]): number {
  const positions = new Map<number, [number] | [number, number]>();
  let best = Number.MAX_SAFE_INTEGER;

  nums.forEach((num, index) => {
    const state = positions.get(num);
    if (state === undefined) {
      positions.set(num, [index]);
      return;
    }

    if (state.length === 1) {
      positions.set(num, [state[0], index]);
      return;
    }

    best = Math.min(best, 2 * (index - state[0]));
    positions.set(num, [state[1], index]);
  });

  return best === Number.MAX_SAFE_INTEGER ? -1 : best;
}
// @lc code=end
