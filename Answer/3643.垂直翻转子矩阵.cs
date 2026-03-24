/*
 * @lc app=leetcode.cn id=3643 lang=csharp
 *
 * [3643] 垂直翻转子矩阵
 */

// @lc code=start
public class Solution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        for (var i = x; i < x + k / 2; i++)
        {
            var t = 2 * x + k - i - 1;
            for (var j = y; j < y + k; j++)
            {
                var temp = grid[i][j];
                grid[i][j] = grid[t][j];
                grid[t][j] = temp;
            }
        }
        return grid;
    }
}
// @lc code=end

