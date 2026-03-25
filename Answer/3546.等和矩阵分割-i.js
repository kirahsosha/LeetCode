/*
 * @lc app=leetcode.cn id=3546 lang=javascript
 *
 * [3546] 等和矩阵分割 I
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @return {boolean}
 */
var canPartitionGrid = function (grid) {
    const m = grid.length;
    const n = grid[0].length;
    if (m === 1 && n === 1) return false;
    const ver = new Array(m).fill(0);
    const hor = new Array(n).fill(0);
    let sum = 0;
    for (let i = 0; i < m; i++) {
        if (i > 0) ver[i] = ver[i - 1];
        for (let j = 0; j < n; j++) {
            ver[i] += grid[i][j];
            hor[j] += grid[i][j];
            if (i === m - 1 && j > 0) {
                hor[j] += hor[j - 1];
            }
            sum += grid[i][j];
        }
    }
    if (sum % 2 !== 0) return false;
    const half = sum / 2;
    if (ver.includes(half)) return true;
    if (hor.includes(half)) return true;
    return false;
};
// @lc code=end

