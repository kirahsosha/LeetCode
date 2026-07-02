/*
 * @lc app=leetcode.cn id=2812 lang=csharp
 *
 * [2812] 找出最安全路径
 */

// @lc code=start
public class Solution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        var n = grid.Count;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
        {
            return 0;
        }
        var safe = new int[n, n];
        var queue = new Queue<(int, int)>();
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    safe[i, j] = 0;
                    queue.Enqueue((i, j));
                }
                else
                {
                    safe[i, j] = int.MaxValue;
                }
            }
        }
        var dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            foreach (var dir in dirs)
            {
                var nx = x + dir[0];
                var ny = y + dir[1];
                if (nx >= 0 && nx < n && ny >= 0 && ny < n && safe[nx, ny] > safe[x, y] + 1)
                {
                    safe[nx, ny] = safe[x, y] + 1;
                    queue.Enqueue((nx, ny));
                }
            }
        }
        var left = 0;
        var right = n * 2;
        while (left < right)
        {
            var mid = (left + right + 1) / 2;
            if (CanReach(safe, mid))
            {
                left = mid;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;
    }

    private bool CanReach(int[,] safe, int factor)
    {
        var n = safe.GetLength(0);
        if (safe[0, 0] < factor || safe[n - 1, n - 1] < factor)
        {
            return false;
        }
        var visited = new bool[n, n];
        var queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        visited[0, 0] = true;
        var dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            if (x == n - 1 && y == n - 1)
            {
                return true;
            }
            foreach (var dir in dirs)
            {
                var nx = x + dir[0];
                var ny = y + dir[1];
                if (nx >= 0 && nx < n && ny >= 0 && ny < n && !visited[nx, ny] && safe[nx, ny] >= factor)
                {
                    visited[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }
        }
        return false;
    }
}
// @lc code=end

