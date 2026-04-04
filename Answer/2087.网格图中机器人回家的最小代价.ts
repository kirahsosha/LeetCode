/*
 * @lc app=leetcode.cn id=2087 lang=typescript
 *
 * [2087] 网格图中机器人回家的最小代价
 */

// @lc code=start
function minCost(
  startPos: number[],
  homePos: number[],
  rowCosts: number[],
  colCosts: number[],
): number {
  const sr = startPos[0],
    sc = startPos[1],
    hr = homePos[0],
    hc = homePos[1];
  let cost = 0;
  if (sr < hr) {
    for (let i = sr + 1; i <= hr; i++) cost += rowCosts[i];
  } else {
    for (let i = sr - 1; i >= hr; i--) cost += rowCosts[i];
  }
  if (sc < hc) {
    for (let j = sc + 1; j <= hc; j++) cost += colCosts[j];
  } else {
    for (let j = sc - 1; j >= hc; j--) cost += colCosts[j];
  }
  return cost;
}
// @lc code=end
