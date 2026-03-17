/*
 * @lc app=leetcode.cn id=3070 lang=java
 *
 * [3070] 元素和小于等于 k 的子矩阵的数目
 */

// @lc code=start
class Solution {
    public int countSubmatrices(int[][] grid, int k) {
        int m = grid.length;
        int n = grid[0].length;
        int[] pre = new int[n];
        int res = 0;
        for (int i = 0; i < m; i++) {
            int sum = 0;
            for (int j = 0; j < n; j++) {
                pre[j] += grid[i][j];
                sum += pre[j];
                if (sum <= k) {
                    res++;
                } else {
                    n = j;
                    break;
                }
            }
        }
        return res;
    }
}
// @lc code=end

