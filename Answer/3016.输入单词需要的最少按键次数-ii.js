/*
 * @lc app=leetcode.cn id=3016 lang=javascript
 *
 * [3016] 输入单词需要的最少按键次数 II
 */

// @lc code=start
/**
 * @param {string} word
 * @return {number}
 */
var minimumPushes = function (word) {
    var cnt = new Array(26).fill(0);
    var aCode = 'a'.charCodeAt(0);
    for (var i = 0; i < word.length; i++) {
        cnt[word.charCodeAt(i) - aCode]++;
    }
    cnt.sort(function (a, b) { return b - a; });
    var ans = 0;
    for (var i = 0; i < 26 && cnt[i] > 0; i++) {
        ans += (Math.floor(i / 8) + 1) * cnt[i];
    }
    return ans;
};
// @lc code=end
