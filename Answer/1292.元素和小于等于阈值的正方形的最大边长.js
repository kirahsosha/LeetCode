/*
 * @lc app=leetcode.cn id=1292 lang=javascript
 *
 * [1292] 元素和小于等于阈值的正方形的最大边长
 */

// @lc code=start
/**
 * @param {number[][]} mat
 * @param {number} threshold
 * @return {number}
 */
var maxSideLength = function (mat, threshold) {
    let m = mat.length;
    let n = mat[0].length;
    let pre = [];
    for (let i = 0; i < m; i++) {
        pre[i] = [];
        pre[i][0] = 0;
        for (let j = 0; j < n; j++) {
            pre[i][j + 1] = pre[i][j] + mat[i][j];
        }
    }

    /**
     * @param {number[][]} len
     * @return {boolean}
     */
    var Check = function (len) {
        for (let i = 0; i <= m - len; i++) {
            for (let j = 0; j <= n - len; j++) {
                let sum = 0;
                for (let k = 0; k < len; k++) {
                    sum += pre[i + k][j + len] - pre[i + k][j];
                }
                if (sum <= threshold) {
                    return true;
                }
            }
        }
        return false;
    }

    let left = 0;
    let right = Math.min(m, n);
    while (left < right) {
        let mid = left + Math.floor((right - left + 1) / 2);
        if (Check(mid)) {
            left = mid;
        }
        else {
            right = mid - 1;
        }
    }
    return left;
};
// @lc code=end

