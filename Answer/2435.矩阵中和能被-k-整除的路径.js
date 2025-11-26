/*
 * @lc app=leetcode.cn id=2435 lang=javascript
 *
 * [2435] 矩阵中和能被 K 整除的路径
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @param {number} k
 * @return {number}
 */
var numberOfPaths = function (grid, k) {
    //dpNew[j][x] = dpOld[j][x+grid[i][j]] + dpNew[j-1][x+grid[i][j]]
    var m = grid.length;
    var n = grid[0].length;
    var dpOld = [];
    var dpNew = [];
    var MOD = 1000000007;

    for (var i = 0; i < m; i++) {
        if (i != 0) {
            dpOld = dpNew;
        }
        dpNew = [];
        for (var j = 0; j < n; j++) {
            dpNew[j] = new Array(k).fill(0);
            if (i == 0 && j == 0) {
                var x = grid[0][0] % k;
                dpNew[0][x] = 1;
            }
            if (j != 0) {
                for (var x = 0; x < k; x++) {
                    if (dpNew[j - 1][x] == 0) {
                        continue;
                    }
                    var y = (x + grid[i][j]) % k;
                    dpNew[j][y] = (dpNew[j][y] + dpNew[j - 1][x]) % MOD;
                }
            }
            if (i != 0) {
                for (var x = 0; x < k; x++) {
                    if (dpOld[j][x] == 0) {
                        continue;
                    }
                    var y = (x + grid[i][j]) % k;
                    dpNew[j][y] = (dpNew[j][y] + dpOld[j][x]) % MOD;
                }
            }
        }
    }
    return dpNew[n - 1][0];
};
// @lc code=end

