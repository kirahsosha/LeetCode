/*
 * @lc app=leetcode.cn id=1930 lang=javascript
 *
 * [1930] 长度为 3 的不同回文子序列
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var countPalindromicSubsequence = function (s) {
    var dic = new Map();
    var res = new Set();
    for (var i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (dic.has(c)) {
            dic.get(c).push(i);
        }
        else {
            dic.set(c, [i]);
        }
    }
    for (var v of dic.values()) {
        if (v.length >= 2) {
            var l = v[0];
            var r = v[v.length - 1];

            for (var j = l + 1; j < r; j++) {
                res.add(s.charAt(l) + s.charAt(j) + s.charAt(r));
            }
        }
    }
    return res.size;
};
// @lc code=end

