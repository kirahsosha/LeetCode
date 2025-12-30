/*
 * @lc app=leetcode.cn id=840 lang=java
 *
 * [840] 矩阵中的幻方
 */

// @lc code=start
import java.util.HashSet;

class Solution {

    public int numMagicSquaresInside(int[][] grid) {
        var n = grid.length;
        var m = grid[0].length;
        var res = 0;
        for (var i = 0; i <= n - 3; i++) {
            for (var j = 0; j <= m - 3; j++) {
                if (IsMagicSquare(grid, i, j)) {
                    res++;
                }
            }
        }
        return res;
    }

    private static boolean IsMagicSquare(int[][] grid, int x, int y) {
        var target = 15;
        HashSet<Integer> seen = new HashSet<>();
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 3; j++) {
                var val = grid[x + i][y + j];
                if (val < 1 || val > 9 || seen.contains(val)) {
                    return false;
                }
                seen.add(val);
            }
        }
        for (int i = 0; i < 3; i++) {
            var rowSum = 0;
            var colSum = 0;
            for (int j = 0; j < 3; j++) {
                rowSum += grid[x + i][y + j];
                colSum += grid[x + j][y + i];
            }
            if (rowSum != target || colSum != target) {
                return false;
            }
        }
        var diag1 = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2];
        var diag2 = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y];
        return !(diag1 != target || diag2 != target);
    }
}
// @lc code=end

