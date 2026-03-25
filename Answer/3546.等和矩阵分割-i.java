/*
 * @lc app=leetcode.cn id=3546 lang=java
 *
 * [3546] 等和矩阵分割 I
 */

// @lc code=start
class Solution {

    public boolean canPartitionGrid(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;
        if (m == 1 && n == 1) {
            return false;
        }
        long[] ver = new long[m];
        long[] hor = new long[n];
        long sum = 0;
        for (int i = 0; i < m; i++) {
            if (i > 0) {
                ver[i] = ver[i - 1];
            }
            for (int j = 0; j < n; j++) {
                ver[i] += grid[i][j];
                hor[j] += grid[i][j];
                if (i == m - 1 && j > 0) {
                    hor[j] += hor[j - 1];
                }
                sum += grid[i][j];
            }
        }
        if (sum % 2 != 0) {
            return false;
        }
        long half = sum / 2;
        for (long v : ver) {
            if (v == half) {
                return true;
            }
        }
        for (long v : hor) {
            if (v == half) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

