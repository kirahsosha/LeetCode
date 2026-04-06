/*
 * @lc app=leetcode.cn id=874 lang=javascript
 *
 * [874] 模拟行走机器人
 */

// @lc code=start
/**
 * @param {number[]} commands
 * @param {number[][]} obstacles
 * @return {number}
 */
var robotSim = function (commands, obstacles) {
  const obs = new Set();
  for (const ob of obstacles) obs.add(`${ob[0]},${ob[1]}`);
  let x = 0,
    y = 0,
    dir = 0,
    ans = 0;
  const dx = [0, 1, 0, -1],
    dy = [1, 0, -1, 0];
  for (const cmd of commands) {
    if (cmd === -2) dir = (dir + 3) % 4;
    else if (cmd === -1) dir = (dir + 1) % 4;
    else {
      for (let step = 0; step < cmd; step++) {
        const nx = x + dx[dir],
          ny = y + dy[dir];
        const key = `${nx},${ny}`;
        if (!obs.has(key)) {
          x = nx;
          y = ny;
          ans = Math.max(ans, x * x + y * y);
        }
      }
    }
  }
  return ans;
};
// @lc code=end
