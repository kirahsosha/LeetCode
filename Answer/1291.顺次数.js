/*
 * @lc app=leetcode.cn id=1291 lang=javascript
 *
 * [1291] 顺次数
 */

// @lc code=start
/**
 * @param {number} low
 * @param {number} high
 * @return {number[]}
 */
var sequentialDigits = function (low, high) {
    var res = [];
    var delta = 1;  // 1, 11, 111, ...
    var offset = 0; // 0, 1, 12, 123, ...
    for (var length = 2; length <= 9; length++) {
        delta = delta * 10 + 1;
        offset = offset * 10 + (length - 1);

        var minNum = delta + offset;
        if (minNum > high) {
            break;
        }
        var maxNum = (10 - length) * delta + offset;
        if (maxNum < low) {
            continue;
        }
        for (var start = 1; start <= 10 - length; start++) {
            var num = start * delta + offset;
            if (num < low) {
                continue;
            }
            if (num > high) {
                break;
            }
            res.push(num);
        }
    }
    return res;
};
// @lc code=end
