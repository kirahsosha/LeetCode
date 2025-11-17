/*
 * @lc app=leetcode.cn id=2257 lang=csharp
 *
 * [2257] 统计网格图中没有被保卫的格子数
 */

// @lc code=start
public class Solution
{
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var guarded = new HashSet<int>();
        var wallSet = new HashSet<int>();
        foreach (var wall in walls)
        {
            guarded.Add(wall[0] * n + wall[1]);
            wallSet.Add(wall[0] * n + wall[1]);
        }
        foreach (var guard in guards)
        {
            guarded.Add(guard[0] * n + guard[1]);
            wallSet.Add(guard[0] * n + guard[1]);
        }
        foreach (var guard in guards)
        {
            int x = guard[0];
            int y = guard[1];
            //up
            for (int i = x - 1; i >= 0; i--)
            {
                if (wallSet.Contains(i * n + y))
                {
                    break;
                }
                else
                {
                    guarded.Add(i * n + y);
                }
            }
            //down
            for (int i = x + 1; i < m; i++)
            {
                if (wallSet.Contains(i * n + y))
                {
                    break;
                }
                else
                {
                    guarded.Add(i * n + y);
                }
            }
            //left
            for (int i = y - 1; i >= 0; i--)
            {
                if (wallSet.Contains(x * n + i))
                {
                    break;
                }
                else
                {
                    guarded.Add(x * n + i);
                }
            }
            //right
            for (int i = y + 1; i < n; i++)
            {
                if (wallSet.Contains(x * n + i))
                {
                    break;
                }
                else
                {
                    guarded.Add(x * n + i);
                }
            }
        }
        return m * n - guarded.Count;
    }
}
// @lc code=end

