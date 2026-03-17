/*
 * @lc app=leetcode.cn id=3070 lang=javascript
 *
 * [3070] 元素和小于等于 k 的子矩阵的数目
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @param {number} k
 * @return {number}
 */
var countSubmatrices = function(grid, k) {
	const m = grid.length;
	let n = grid[0].length;
	const pre = new Array(n).fill(0);
	let res = 0;
	for (let i = 0; i < m; i++) {
		let sum = 0;
		for (let j = 0; j < n; j++) {
			pre[j] += grid[i][j];
			sum += pre[j];
			if (sum <= k) {
				res++;
			} else {
				n = j;
				break;
			}
		}
	}
	return res;
};
// @lc code=end

