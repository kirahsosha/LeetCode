/*
 * @lc app=leetcode.cn id=2833 lang=typescript
 *
 * [2833] 距离原点最远的点
 */

// @lc code=start
function furthestDistanceFromOrigin(moves: string): number {
  let left = 0,
    right = 0;
  for (const c of moves) {
    if (c === "L") {
      left++;
      right--;
    } else if (c === "R") {
      right++;
      left--;
    } else {
      left++;
      right++;
    }
  }
  return Math.max(left, right);
}
// @lc code=end
