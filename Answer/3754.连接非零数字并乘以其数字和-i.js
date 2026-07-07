/*
 * @lc app=leetcode.cn id=3754 lang=javascript
 *
 * [3754] 连接非零数字并乘以其数字和 I
 */

// @lc code=start
/**
 * @param {number} n
 * @return {number}
 */
var sumAndMultiply = function (n) {
    var x = 0;
    var pow = 1;
    var sum = 0;
    while (n > 0) {
        var d = n % 10;
        if (d !== 0) {
            x += d * pow;
            pow *= 10;
            sum += d;
        }
        n = Math.floor(n / 10);
    }
    return x * sum;
};
// @lc code=end
