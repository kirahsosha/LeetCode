/*
 * @lc app=leetcode.cn id=3643 lang=typescript
 *
 * [3643] 垂直翻转子矩阵
 */

// @lc code=start
function reverseSubmatrix(grid: number[][], x: number, y: number, k: number): number[][] {
	for (let i = x; i < x + Math.floor(k / 2); i++) {
		const t = 2 * x + k - i - 1;
		for (let j = y; j < y + k; j++) {
			const temp = grid[i][j];
			grid[i][j] = grid[t][j];
			grid[t][j] = temp;
		}
	}
	return grid;
};
// @lc code=end

