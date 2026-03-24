/*
 * @lc app=leetcode.cn id=1594 lang=java
 *
 * [1594] 矩阵的最大非负积
 */

// @lc code=start
class Solution {

    public int maxProductPath(int[][] grid) {
        final int MOD = 1000000007;
        int m = grid.length;
        int n = grid[0].length;
        long[][][] dp = new long[m][n][2];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) {
                    dp[i][j][0] = grid[i][j];
                    dp[i][j][1] = grid[i][j];
                } else if (i == 0) {
                    long maxVal = dp[i][j - 1][0] * grid[i][j];
                    long minVal = dp[i][j - 1][1] * grid[i][j];
                    dp[i][j][0] = Math.max(maxVal, minVal);
                    dp[i][j][1] = Math.min(maxVal, minVal);
                } else if (j == 0) {
                    long maxVal = dp[i - 1][j][0] * grid[i][j];
                    long minVal = dp[i - 1][j][1] * grid[i][j];
                    dp[i][j][0] = Math.max(maxVal, minVal);
                    dp[i][j][1] = Math.min(maxVal, minVal);
                } else if (grid[i][j] > 0) {
                    long maxVal = Math.max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j];
                    long minVal = Math.min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j];
                    dp[i][j][0] = Math.max(maxVal, minVal);
                    dp[i][j][1] = Math.min(maxVal, minVal);
                } else if (grid[i][j] < 0) {
                    long maxVal = Math.min(dp[i - 1][j][1], dp[i][j - 1][1]) * grid[i][j];
                    long minVal = Math.max(dp[i - 1][j][0], dp[i][j - 1][0]) * grid[i][j];
                    dp[i][j][0] = Math.max(maxVal, minVal);
                    dp[i][j][1] = Math.min(maxVal, minVal);
                } else {
                    dp[i][j][0] = 0;
                    dp[i][j][1] = 0;
                }
            }
        }
        long val = Math.max(dp[m - 1][n - 1][0], dp[m - 1][n - 1][1]);
        if (val < 0) {
            return -1;
        }
        return (int) (val % MOD);
    }
}
// @lc code=end

