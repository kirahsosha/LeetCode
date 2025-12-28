/*
 * @lc app=leetcode.cn id=1351 lang=java
 *
 * [1351] 统计有序矩阵中的负数
 */

// @lc code=start
class Solution {

    public int countNegatives(int[][] grid) {
        var m = grid.length;
        var n = grid[0].length;
        var ans = 0;
        var j = 0;
        for (var i = m - 1; i >= 0; i--) {
            while (j < n) {
                if (grid[i][j] < 0) {
                    ans += n - j;
                    break;
                }
                j++;
            }
        }
        return ans;
    }
}
// @lc code=end

