/*
 * @lc app=leetcode.cn id=3612 lang=javascript
 *
 * [3612] 用特殊操作处理字符串 I
 */

// @lc code=start
/**
 * @param {string} s
 * @return {string}
 */
var processStr = function (s) {
    var res = '';
    for (var i = 0; i < s.length; i++) {
        var ch = s[i];
        if (ch == '*') {
            res = res.slice(0, -1);
        } else if (ch == '#') {
            res += res;
        } else if (ch == '%') {
            res = res.split('').reverse().join('');
        } else {
            res += ch;
        }
    }
    return res;
};
// @lc code=end
