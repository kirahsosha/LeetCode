/*
 * @lc app=leetcode.cn id=3536 lang=javascript
 *
 * [3536] 两个数字的最大乘积
 */

// @lc code=start
/**
 * @param {number} n
 * @return {number}
 */
var maxProduct = function (n) {
    var digit = 0;
    var ans = 0;
    while (n > 0) {
        var d = n % 10;
        ans = Math.max(ans, d * digit);
        digit = Math.max(digit, d);
        n = Math.floor(n / 10);
    }
    return ans;
};
// @lc code=end
