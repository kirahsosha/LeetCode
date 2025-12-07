/*
 * @lc app=leetcode.cn id=1523 lang=javascript
 *
 * [1523] 在区间范围内统计奇数数目
 */

// @lc code=start
/**
 * @param {number} low
 * @param {number} high
 * @return {number}
 */
var countOdds = function (low, high) {
    let interval = high - low + 1;
    if (interval % 2 == 0) {
        return Math.floor(interval / 2);
    } else if (low % 2 == 0) {
        return Math.floor(interval / 2);
    } else {
        return Math.floor(interval / 2) + 1;
    }
};
// @lc code=end

