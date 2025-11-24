/*
 * @lc app=leetcode.cn id=509 lang=javascript
 *
 * [509] 斐波那契数
 */

// @lc code=start
/**
 * @param {number} n
 * @return {number}
 */
var fib = function (n) {
    //dp[n] = dp[n - 1] + dp[n - 2]
    if (n == 0) {
        return 0;
    }
    if (n == 1) {
        return 1;
    }

    var dp = [];
    dp[0] = 0;
    dp[1] = 1;
    for (var i = 2; i <= n; i++) {
        dp[i] = dp[i - 1] + dp[i - 2];
    }
    return dp[n];
};
// @lc code=end

