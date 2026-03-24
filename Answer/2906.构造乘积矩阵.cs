/*
 * @lc app=leetcode.cn id=2906 lang=csharp
 *
 * [2906] 构造乘积矩阵
 */

// @lc code=start
public class Solution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        var mod = 12345;
        var n = grid.Length;
        var m = grid[0].Length;
        var left = new long[n * m + 1];
        var right = new long[n * m + 1];
        left[0] = 1;
        right[^1] = 1;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                left[i * m + j + 1] = left[i * m + j] * grid[i][j] % mod;
            }
        }

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = m - 1; j >= 0; j--)
            {
                right[i * m + j] = right[i * m + j + 1] * grid[i][j] % mod;
            }
        }

        var p = new int[n][];
        for (var i = 0; i < n; i++)
        {
            p[i] = new int[m];
            for (var j = 0; j < m; j++)
            {
                p[i][j] = (int)(left[i * m + j] * right[i * m + j + 1] % mod);
            }
        }

        return p;
    }
}
// @lc code=end

