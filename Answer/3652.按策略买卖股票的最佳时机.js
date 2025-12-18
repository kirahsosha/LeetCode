/*
 * @lc app=leetcode.cn id=3652 lang=javascript
 *
 * [3652] 按策略买卖股票的最佳时机
 */

// @lc code=start
/**
 * @param {number[]} prices
 * @param {number[]} strategy
 * @param {number} k
 * @return {number}
 */
var maxProfit = function (prices, strategy, k) {
    let res = 0;
    var n = prices.length;
    for (let i = 0; i < n; i++) {
        res += prices[i] * strategy[i];
    }

    var t = k / 2;
    let max = res;
    for (let i = 0; i < t; i++) {
        res -= prices[i] * strategy[i];
    }
    for (let i = t; i < k; i++) {
        res += prices[i] * (1 - strategy[i]);
    }
    max = Math.max(max, res);
    for (let i = 0; i < n - k; i++) {
        res += prices[i] * strategy[i];
        res -= prices[i + t];
        res += prices[i + k] * (1 - strategy[i + k]);
        max = Math.max(max, res);
    }
    return max;
};
// @lc code=end

