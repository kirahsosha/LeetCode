/*
 * @lc app=leetcode.cn id=3652 lang=java
 *
 * [3652] 按策略买卖股票的最佳时机
 */

// @lc code=start
class Solution {

    public long maxProfit(int[] prices, int[] strategy, int k) {
        long res = 0;
        var n = prices.length;
        for (int i = 0; i < n; i++) {
            res += prices[i] * strategy[i];
        }

        var t = k / 2;
        long max = res;
        for (int i = 0; i < t; i++) {
            res -= prices[i] * strategy[i];
        }
        for (int i = t; i < k; i++) {
            res += prices[i] * (1 - strategy[i]);
        }
        max = Math.max(max, res);
        for (int i = 0; i < n - k; i++) {
            res += prices[i] * strategy[i];
            res -= prices[i + t];
            res += prices[i + k] * (1 - strategy[i + k]);
            max = Math.max(max, res);
        }
        return max;
    }
}
// @lc code=end

