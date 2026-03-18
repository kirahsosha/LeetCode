/*
 * @lc app=leetcode.cn id=3212 lang=typescript
 *
 * [3212] 统计 X 和 Y 频数相等的子矩阵数量
 */

// @lc code=start
function numberOfSubmatrices(grid: string[][]): number {
	const m = grid.length;
	const n = grid[0].length;
	const cntX: number[] = new Array(n).fill(0);
	const cntY: number[] = new Array(n).fill(0);
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

