/*
 * @lc app=leetcode.cn id=2946 lang=javascript
 *
 * [2946] 循环移位后的矩阵相似检查
 */

// @lc code=start
/**
 * @param {number[][]} mat
 * @param {number} k
 * @return {boolean}
 */
var areSimilar = function (mat, k) {
    const m = mat.length;
    const n = mat[0].length;
    k %= n;
    if (k === 0) return true;

    for (let i = 0; i < m; i++) {
        const row = mat[i];
        if ((i & 1) === 0) {
            for (let j = 0; j < n; j++) {
                if (row[j] !== row[(j + k) % n]) {
                    return false;
                }
            }
        } else {
            for (let j = 0; j < n; j++) {
                if (row[j] !== row[(j - k + n) % n]) {
                    return false;
                }
            }
        }
    }
    return true;
};
// @lc code=end

