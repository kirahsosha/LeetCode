/*
 * @lc app=leetcode.cn id=840 lang=javascript
 *
 * [840] 矩阵中的幻方
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @return {number}
 */
var numMagicSquaresInside = function (grid) {
    let n = grid.length;
    let m = grid[0].length;
    let res = 0;
    for (let i = 0; i <= n - 3; i++) {
        for (let j = 0; j <= m - 3; j++) {
            if (IsMagicSquare(i, j)) {
                res++;
            }
        }
    }
    return res;

    function IsMagicSquare(x, y) {
        let target = 15;
        let seen = new Set();
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                let val = grid[x + i][y + j];
                if (val < 1 || val > 9 || seen.has(val)) {
                    return false;
                }
                seen.add(val);
            }
        }
        for (let i = 0; i < 3; i++) {
            let rowSum = 0;
            let colSum = 0;
            for (let j = 0; j < 3; j++) {
                rowSum += grid[x + i][y + j];
                colSum += grid[x + j][y + i];
            }
            if (rowSum != target || colSum != target) {
                return false;
            }
        }
        let diag1 = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2];
        let diag2 = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y];
        if (diag1 != target || diag2 != target) {
            return false;
        }
        return true;
    }
};
// @lc code=end

