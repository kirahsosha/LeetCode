/*
 * @lc app=leetcode.cn id=3212 lang=javascript
 *
 * [3212] 统计 X 和 Y 频数相等的子矩阵数量
 */

// @lc code=start
/**
 * @param {character[][]} grid
 * @return {number}
 */
var numberOfSubmatrices = function(grid) {
	const m = grid.length;
	const n = grid[0].length;
	const cntX = new Array(n).fill(0);
	const cntY = new Array(n).fill(0);
	let res = 0;
	for (let i = 0; i < m; i++) {
		let sumX = 0;
		let sumY = 0;
		for (let j = 0; j < n; j++) {
			cntX[j] += grid[i][j] === 'X' ? 1 : 0;
			cntY[j] += grid[i][j] === 'Y' ? 1 : 0;
			sumX += cntX[j];
			sumY += cntY[j];
			if (sumX === sumY && sumX > 0) {
				res++;
			}
		}
	}
	return res;
};
// @lc code=end

