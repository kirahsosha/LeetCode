/*
 * @lc app=leetcode.cn id=2144 lang=typescript
 *
 * [2144] 打折购买糖果的最小开销
 */

// @lc code=start
function minimumCost(cost: number[]): number {
  cost.sort((a, b) => a - b);
  let totalCost = 0;
  for (let i = cost.length - 1; i >= 0; i -= 3) {
    totalCost += cost[i];
    if (i > 0) {
      totalCost += cost[i - 1];
    }
  }
  return totalCost;
}
// @lc code=end
