/*
 * @lc app=leetcode.cn id=1758 lang=javascript
 *
 * [1758] 生成交替二进制字符串的最少操作数
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var minOperations = function (s) {
    var res0 = 0;
    var res1 = 0;
    for (var i = 0; i < s.length; i++) {
        if (s.charAt(i) - '0' != i % 2) {
            res0++;
        } else {
            res1++;
        }
    }
    return Math.min(res0, res1);
};
// @lc code=end

