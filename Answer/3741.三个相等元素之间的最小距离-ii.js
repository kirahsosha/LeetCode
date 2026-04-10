/*
 * @lc app=leetcode.cn id=3741 lang=javascript
 *
 * [3741] 三个相等元素之间的最小距离 II
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minimumDistance = function (nums) {
  const positions = new Map();
  let best = Number.MAX_SAFE_INTEGER;

  nums.forEach((num, index) => {
    const state = positions.get(num);
    if (state === undefined) {
      positions.set(num, [index]);
      return;
    }

    if (state.length === 1) {
      state.push(index);
      return;
    }

    best = Math.min(best, 2 * (index - state[0]));
    state[0] = state[1];
    state[1] = index;
  });

  return best === Number.MAX_SAFE_INTEGER ? -1 : best;
};
// @lc code=end
