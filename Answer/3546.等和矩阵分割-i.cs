/*
 * @lc app=leetcode.cn id=3546 lang=csharp
 *
 * [3546] 等和矩阵分割 I
 */

// @lc code=start
public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        if (m == 1 && n == 1) return false;
        var ver = new long[m];
        var hor = new long[n];
        long sum = 0;
        for (var i = 0; i < m; i++)
        {
            if (i > 0)
            {
                ver[i] = ver[i - 1];
            }
            for (var j = 0; j < n; j++)
            {
                ver[i] += grid[i][j];
                hor[j] += grid[i][j];
                if (i == m - 1 && j > 0)
                {
                    hor[j] += hor[j - 1];
                }
                sum += grid[i][j];
            }
        }
        if (sum % 2 != 0) return false;
        if (ver.Contains(sum / 2)) return true;
        if (hor.Contains(sum / 2)) return true;
        return false;
    }
}
// @lc code=end

