/*
 * @lc app=leetcode.cn id=2943 lang=javascript
 *
 * [2943] 最大化网格图中正方形空洞的面积
 */

// @lc code=start
/**
 * @param {number} n
 * @param {number} m
 * @param {number[]} hBars
 * @param {number[]} vBars
 * @return {number}
 */
var maximizeSquareHoleArea = function (n, m, hBars, vBars) {
    hBars.sort((a, b) => a - b);
    var hMax = 1;
    var left = 1;
    var right = 2;
    hBars.forEach(bar => {
        if (bar == right) {
            right = bar + 1;
        } else {
            left = bar - 1;
            right = bar + 1;
        }
        hMax = Math.max(hMax, right - left);
    });

    vBars.sort((a, b) => a - b);
    var vMax = 1;
    left = 1;
    right = 2;
    vBars.forEach(bar => {
        if (bar == right) {
            right = bar + 1;
        } else {
            left = bar - 1;
            right = bar + 1;
        }
        vMax = Math.max(vMax, right - left);
    });

    var l = Math.min(hMax, vMax);
    return l * l;
};
// @lc code=end

