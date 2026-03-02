/*
 * @lc app=leetcode.cn id=1536 lang=javascript
 *
 * [1536] 排布二进制网格的最少交换次数
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @return {number}
 */
var minSwaps = function (grid) {
    let n = grid.length;
    let aim = new Array(n);
    for (let i = 0; i < n; i++) {
        let count = n - 1;
        for (let j = n - 1; j >= 0; j--) {
            count = j;
            if (grid[i][j] == 1) {
                break;
            }
        }
        aim[i] = count;
    }
    let ans = 0;
    for (let i = 0; i < n; i++) {
        let j = i;
        while (j < n && aim[j] > i) {
            j++;
        }
        if (j == n) {
            return -1;
        }
        ans += j - i;
        for (let k = j; k > i; k--) {
            aim[k] = aim[k - 1];
        }
    }
    return ans;
};
// @lc code=end

