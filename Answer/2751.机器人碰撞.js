/*
 * @lc app=leetcode.cn id=2751 lang=javascript
 *
 * [2751] 机器人碰撞
 */

// @lc code=start
/**
 * @param {number[]} positions
 * @param {number[]} healths
 * @param {string} directions
 * @return {number[]}
 */
var survivedRobotsHealths = function (positions, healths, directions) {
  const n = positions.length;
  const order = Array.from({ length: n }, (_, i) => i);
  order.sort((a, b) => positions[a] - positions[b]);

  const rightStack = [];
  for (const i of order) {
    if (directions[i] === "R") {
      rightStack.push(i);
      continue;
    }

    while (rightStack.length > 0 && healths[i] > 0) {
      const j = rightStack[rightStack.length - 1];
      if (healths[j] < healths[i]) {
        rightStack.pop();
        healths[i]--;
        healths[j] = 0;
      } else if (healths[j] > healths[i]) {
        healths[j]--;
        healths[i] = 0;
      } else {
        rightStack.pop();
        healths[j] = 0;
        healths[i] = 0;
      }
    }
  }

  const ans = [];
  for (let i = 0; i < n; i++) {
    if (healths[i] > 0) {
      ans.push(healths[i]);
    }
  }

  return ans;
};
// @lc code=end
