/*
 * @lc app=leetcode.cn id=1189 lang=javascript
 *
 * [1189] “气球” 的最大数量
 */

// @lc code=start
/**
 * @param {string} text
 * @return {number}
 */
var maxNumberOfBalloons = function (text) {
    var cnt = new Array(26).fill(0);
    var aCode = 'a'.charCodeAt(0);
    for (var i = 0; i < text.length; i++) {
        cnt[text.charCodeAt(i) - aCode]++;
    }
    return Math.min(
        Math.min(cnt['b'.charCodeAt(0) - aCode], cnt['a'.charCodeAt(0) - aCode]),
        Math.min(cnt['l'.charCodeAt(0) - aCode] >> 1, cnt['o'.charCodeAt(0) - aCode] >> 1),
        cnt['n'.charCodeAt(0) - aCode]
    );
};
// @lc code=end
