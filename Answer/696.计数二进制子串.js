/*
 * @lc app=leetcode.cn id=696 lang=javascript
 *
 * [696] 计数二进制子串
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var countBinarySubstrings = function (s) {
    var a = '0';
    var count = 0;
    var old = 0;
    var res = 0;
    s.split('').forEach(c => {
        if (c == a) {
            count++;
        } else {
            res += Math.min(old, count);
            old = count;
            a = c;
            count = 1;
        }
    });
    res += Math.min(old, count);
    return res;
};
// @lc code=end

