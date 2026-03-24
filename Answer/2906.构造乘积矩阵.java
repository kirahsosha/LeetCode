/*
 * @lc app=leetcode.cn id=2906 lang=java
 *
 * [2906] 构造乘积矩阵
 */

// @lc code=start
class Solution {

    public int[][] constructProductMatrix(int[][] grid) {
        int mod = 12345;
        int n = grid.length;
        int m = grid[0].length;
        long[] left = new long[n * m + 1];
        long[] right = new long[n * m + 1];
        left[0] = 1;
        right[right.length - 1] = 1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                left[i * m + j + 1] = left[i * m + j] * grid[i][j] % mod;
            }
        }

        for (int i = n - 1; i >= 0; i--) {
            for (int j = m - 1; j >= 0; j--) {
                right[i * m + j] = right[i * m + j + 1] * grid[i][j] % mod;
            }
        }

        int[][] p = new int[n][m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                p[i][j] = (int) (left[i * m + j] * right[i * m + j + 1] % mod);
            }
        }

        return p;
    }
}
// @lc code=end

