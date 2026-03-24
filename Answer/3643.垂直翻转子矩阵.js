/*
 * @lc app=leetcode.cn id=3643 lang=javascript
 *
 * [3643] 垂直翻转子矩阵
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @param {number} x
 * @param {number} y
 * @param {number} k
 * @return {number[][]}
 */
var reverseSubmatrix = function (grid, x, y, k) {
    for (let i = x; i < x + Math.floor(k / 2); i++) {
        const t = 2 * x + k - i - 1;
        for (let j = y; j < y + k; j++) {
            const temp = grid[i][j];
            grid[i][j] = grid[t][j];
            grid[t][j] = temp;
        }
    }
    return grid;
};
// @lc code=end

