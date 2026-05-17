/*
 * @lc app=leetcode.cn id=1306 lang=javascript
 *
 * [1306] 跳跃游戏 III
 */

// @lc code=start
/**
 * @param {number[]} arr
 * @param {number} start
 * @return {boolean}
 */
var canReach = function (arr, start) {
  var visited = new Array(arr.length).fill(false);
  var stack = [start];
  visited[start] = true;
  while (stack.length > 0) {
    var index = stack.pop();
    if (arr[index] === 0) {
      return true;
    }

    var next = index + arr[index];
    if (next < arr.length && !visited[next]) {
      visited[next] = true;
      stack.push(next);
    }

    var prev = index - arr[index];
    if (prev >= 0 && !visited[prev]) {
      visited[prev] = true;
      stack.push(prev);
    }
  }

  return false;
};
// @lc code=end
