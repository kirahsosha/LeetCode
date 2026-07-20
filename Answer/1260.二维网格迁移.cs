/*
 * @lc app=leetcode.cn id=1260 lang=csharp
 *
 * [1260] 二维网格迁移
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var total = m * n;
        k %= total;
        if (k == 0) { return grid; }

        var vertex = new List<IList<int>>();
        var x = (total - k) / n;
        var y = (total - k) % n;
        for (var i = 0; i < m; i++)
        {
            var row = new List<int>();
            for (var j = 0; j < n; j++)
            {
                row.Add(grid[x][y]);
                y += 1;
                if (y >= n)
                {
                    y = 0;
                    x += 1;
                    if (x >= m)
                    {
                        x = 0;
                    }
                }
            }
            vertex.Add(row);
        }

        return vertex;
    }
}
// @lc code=end

