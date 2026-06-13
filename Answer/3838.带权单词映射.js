/*
 * @lc app=leetcode.cn id=3838 lang=javascript
 *
 * [3838] 带权单词映射
 */

// @lc code=start
/**
 * @param {string[]} words
 * @param {number[]} weights
 * @return {string}
 */
var mapWordWeights = function (words, weights) {
    var res = [];
    for (var i = 0; i < words.length; i++) {
        var word = words[i];
        var w = 0;
        for (var j = 0; j < word.length; j++) {
            w = (w + weights[word.charCodeAt(j) - 97]) % 26;
        }
        res.push(String.fromCharCode(97 + 25 - w));
    }
    return res.join('');
};
// @lc code=end
