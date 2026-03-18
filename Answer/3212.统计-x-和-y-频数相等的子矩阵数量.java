/*
 * @lc app=leetcode.cn id=3212 lang=java
 *
 * [3212] 统计 X 和 Y 频数相等的子矩阵数量
 */

// @lc code=start
class Solution {
    public int numberOfSubmatrices(char[][] grid) {
        int m = grid.length;
        int n = grid[0].length;
        int[] cntX = new int[n];
        int[] cntY = new int[n];
        int res = 0;
        for (int i = 0; i < m; i++) {
            int sumX = 0;
            int sumY = 0;
            for (int j = 0; j < n; j++) {
                cntX[j] += grid[i][j] == 'X' ? 1 : 0;
                cntY[j] += grid[i][j] == 'Y' ? 1 : 0;
                sumX += cntX[j];
                sumY += cntY[j];
                if (sumX == sumY && sumX > 0) {
                    res++;
                }
            }
        }
        return res;
    }
}
// @lc code=end

