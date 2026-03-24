/*
 * @lc app=leetcode.cn id=3643 lang=java
 *
 * [3643] 垂直翻转子矩阵
 */

// @lc code=start
class Solution {

    public int[][] reverseSubmatrix(int[][] grid, int x, int y, int k) {
        for (int i = x; i < x + k / 2; i++) {
            int t = 2 * x + k - i - 1;
            for (int j = y; j < y + k; j++) {
                int temp = grid[i][j];
                grid[i][j] = grid[t][j];
                grid[t][j] = temp;
            }
        }
        return grid;
    }
}
// @lc code=end

