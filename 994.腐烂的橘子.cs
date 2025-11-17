/*
 * @lc app=leetcode.cn id=994 lang=csharp
 *
 * [994] 腐烂的橘子
 */

// @lc code=start
public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        var rot = new List<Tuple<int, int>>();
        var fresh = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    rot.Add(new Tuple<int, int>(i, j));
                }
                else if (grid[i][j] == 1)
                {
                    fresh++;
                }
            }
        }
        if (fresh == 0) return 0;
        if (rot.Count == 0) return -1;
        int d = 0;
        while (d >= 0)
        {
            d++;
            var rot2 = new List<Tuple<int, int>>();
            int count = 0;
            foreach (var r in rot)
            {
                int i = r.Item1;
                int j = r.Item2;
                if (i - 1 >= 0 && grid[i - 1][j] == 1)
                {
                    grid[i - 1][j] = 2;
                    rot2.Add(new Tuple<int, int>(i - 1, j));
                    count++;
                    fresh--;
                }
                if (j - 1 >= 0 && grid[i][j - 1] == 1)
                {
                    grid[i][j - 1] = 2;
                    rot2.Add(new Tuple<int, int>(i, j - 1));
                    count++;
                    fresh--;
                }
                if (i + 1 < grid.Length && grid[i + 1][j] == 1)
                {
                    grid[i + 1][j] = 2;
                    rot2.Add(new Tuple<int, int>(i + 1, j));
                    count++;
                    fresh--;
                }
                if (j + 1 < grid[0].Length && grid[i][j + 1] == 1)
                {
                    grid[i][j + 1] = 2;
                    rot2.Add(new Tuple<int, int>(i, j + 1));
                    count++;
                    fresh--;
                }
            }
            if (count == 0 || fresh == 0) break;
            rot = rot2;
        }
        if (fresh == 0) return d;
        return -1;
    }
}
// @lc code=end

