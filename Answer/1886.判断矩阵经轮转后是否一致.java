/*
 * @lc app=leetcode.cn id=1886 lang=java
 *
 * [1886] 判断矩阵经轮转后是否一致
 */

// @lc code=start
class Solution {

    public boolean findRotation(int[][] mat, int[][] target) {
        int n = mat.length;
        boolean r1 = true, r2 = true, r3 = true, r4 = true;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (r1 && mat[i][j] != target[i][j]) {
                    r1 = false;
                }
                if (r2 && mat[i][j] != target[j][n - i - 1]) {
                    r2 = false;
                }
                if (r3 && mat[i][j] != target[n - i - 1][n - j - 1]) {
                    r3 = false;
                }
                if (r4 && mat[i][j] != target[n - j - 1][i]) {
                    r4 = false;
                }
            }
        }
        return r1 || r2 || r3 || r4;
    }
}
// @lc code=end

