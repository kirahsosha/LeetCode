/*
 * @lc app=leetcode.cn id=1331 lang=javascript
 *
 * [1331] 数组序号转换
 */

// @lc code=start
/**
 * @param {number[]} arr
 * @return {number[]}
 */
var arrayRankTransform = function (arr) {
    var sorted = arr.slice().sort(function (a, b) { return a - b; });
    var rank = new Map();
    var r = 1;
    for (var i = 0; i < sorted.length; i++) {
        if (!rank.has(sorted[i])) {
            rank.set(sorted[i], r++);
        }
    }
    var ans = new Array(arr.length);
    for (var i = 0; i < arr.length; i++) {
        ans[i] = rank.get(arr[i]);
    }
    return ans;
};
// @lc code=end
