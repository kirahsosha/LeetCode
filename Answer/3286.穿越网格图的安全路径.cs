/*
 * @lc app=leetcode.cn id=3286 lang=csharp
 *
 * [3286] 穿越网格图的安全路径
 */

using System.Collections.Generic;

// @lc code=start
public class Solution
{
    public bool FindSafeWalk(IList<IList<int>> grid, int health)
    {
        int m = grid.Count;
        int n = grid[0].Count;
        int init = health - grid[0][0];
        if (init <= 0)
        {
            return false;
        }

        var seen = new bool[m, n, health + 1];
        var q = new Queue<(int, int, int)>();
        q.Enqueue((0, 0, init));
        seen[0, 0, init] = true;

        int[] dirs = new int[] { -1, 0, 1, 0, -1 };
        while (q.Count > 0)
        {
            var (x, y, h) = q.Dequeue();
            if (x == m - 1 && y == n - 1)
            {
                return true;
            }
            for (int k = 0; k < 4; k++)
            {
                int nx = x + dirs[k];
                int ny = y + dirs[k + 1];
                if (nx < 0 || nx >= m || ny < 0 || ny >= n)
                {
                    continue;
                }
                int nh = h - grid[nx][ny];
                if (nh > 0 && !seen[nx, ny, nh])
                {
                    seen[nx, ny, nh] = true;
                    q.Enqueue((nx, ny, nh));
                }
            }
        }
        return false;
    }
}
// @lc code=end
