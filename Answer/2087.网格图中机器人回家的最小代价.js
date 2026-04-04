/*
 * @lc app=leetcode.cn id=2087 lang=javascript
 *
 * [2087] 网格图中机器人回家的最小代价
 */

// @lc code=start
/**
 * @param {number[]} startPos
 * @param {number[]} homePos
 * @param {number[]} rowCosts
 * @param {number[]} colCosts
 * @return {number}
 */
var minCost = function (startPos, homePos, rowCosts, colCosts) {
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
};
// @lc code=end
