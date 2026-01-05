/*
 * @lc app=leetcode.cn id=1975 lang=javascript
 *
 * [1975] 最大方阵和
 */

// @lc code=start
/**
 * @param {number[][]} matrix
 * @return {number}
 */
var maxMatrixSum = function (matrix) {
    let n = matrix.length;
    let sumPos = 0;
    let sumNeg = 0;
    let maxNeg = -100001;
    let minPos = 100001;
    let countPos = 0;
    let countNeg = 0;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            let k = matrix[i][j];
            if (k >= 0) {
                countPos++;
                sumPos += k;
                minPos = Math.min(minPos, k);
            } else {
                countNeg++;
                sumNeg -= k;
                maxNeg = Math.max(maxNeg, k);
            }
        }
    }
    if (countNeg % 2 == 0) {
        return sumPos + sumNeg;
    } else if (countPos == 0) {
        return sumPos + sumNeg + 2 * maxNeg;
    } else {
        return Math.max(sumPos + sumNeg + 2 * maxNeg, sumPos + sumNeg - 2 * minPos);
    }
};
// @lc code=end

