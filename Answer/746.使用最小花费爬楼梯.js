/*
 * @lc app=leetcode.cn id=746 lang=javascript
 *
 * [746] 使用最小花费爬楼梯
 */

// @lc code=start
/**
 * @param {number[]} cost
 * @return {number}
 */
var minCostClimbingStairs = function (cost) {
    //dp[0] = cost[0]
    //dp[1] = cost[1]
    //dp[i] = min(dp[i-1], dp[i-2]) + cost[i]
    var n = cost.length;
    if (n == 2) {
        return Math.min(cost[0], cost[1]);
    }
    var dp = [];
    dp[0] = cost[0];
    dp[1] = cost[1];
    for (var i = 2; i < n; i++) {
        dp[i] = Math.min(dp[i - 2], dp[i - 1]) + cost[i];
    }
    return Math.min(dp[n - 2], dp[n - 1]);
};
// @lc code=end

