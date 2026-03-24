/*
 * @lc app=leetcode.cn id=2906 lang=javascript
 *
 * [2906] 构造乘积矩阵
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @return {number[][]}
 */
var constructProductMatrix = function (grid) {
    const mod = 12345;
    const n = grid.length;
    const m = grid[0].length;
    const left = new Array(n * m + 1).fill(0);
    const right = new Array(n * m + 1).fill(0);
    left[0] = 1;
    right[right.length - 1] = 1;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            left[i * m + j + 1] = (left[i * m + j] * grid[i][j]) % mod;
        }
    }

    for (let i = n - 1; i >= 0; i--) {
        for (let j = m - 1; j >= 0; j--) {
            right[i * m + j] = (right[i * m + j + 1] * grid[i][j]) % mod;
        }
    }

    const p = new Array(n);
    for (let i = 0; i < n; i++) {
        p[i] = new Array(m).fill(0);
        for (let j = 0; j < m; j++) {
            p[i][j] = (left[i * m + j] * right[i * m + j + 1]) % mod;
        }
    }
    return p;
};
// @lc code=end

