/*
 * @lc app=leetcode.cn id=1594 lang=typescript
 *
 * [1594] 矩阵的最大非负积
 */

// @lc code=start
function maxProductPath(grid: number[][]): number {
	const MOD = 1000000007;
	const m = grid.length;
	const n = grid[0].length;
	const dp: number[][][] = Array.from({ length: m }, () => Array.from({ length: n }, () => [0, 0]));
	for (let i = 0; i < m; i++) {
		for (let j = 0; j < n; j++) {
			if (i === 0 && j === 0) {
				dp[i][j][0] = grid[i][j];
				dp[i][j][1] = grid[i][j];
			} else if (i === 0) {
				const maxVal = dp[i][j - 1][0] * grid[i][j];
				const minVal = dp[i][j - 1][1] * grid[i][j];
				dp[i][j][0] = Math.max(maxVal, minVal);
				dp[i][j][1] = Math.min(maxVal, minVal);
			} else if (j === 0) {
				const maxVal = dp[i - 1][j][0] * grid[i][j];
				const minVal = dp[i - 1][j][1] * grid[i][j];
				dp[i][j][0] = Math.max(maxVal, minVal);
				dp[i][j][1] = Math.min(maxVal, minVal);
			} else if (grid[i][j] > 0) {
				const maxVal = Math.max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j];
				const minVal = Math.min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j];
				dp[i][j][0] = Math.max(maxVal, minVal);
				dp[i][j][1] = Math.min(maxVal, minVal);
			} else if (grid[i][j] < 0) {
				const maxVal = Math.min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j];
				const minVal = Math.max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j];
				dp[i][j][0] = Math.max(maxVal, minVal);
				dp[i][j][1] = Math.min(maxVal, minVal);
			} else {
				dp[i][j][0] = 0;
				dp[i][j][1] = 0;
			}
		}
	}
	const val = Math.max(dp[m - 1][n - 1][0], dp[m - 1][n - 1][1]);
	return val < 0 ? -1 : val % MOD;
};
// @lc code=end

