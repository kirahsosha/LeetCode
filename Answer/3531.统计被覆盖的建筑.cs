/*
 * @lc app=leetcode.cn id=3531 lang=csharp
 *
 * [3531] 统计被覆盖的建筑
 */

// @lc code=start
public class Solution
{
    public int CountCoveredBuildings(int n, int[][] buildings)
    {
        //Key：横坐标；Value：纵坐标范围
        var ver = new Dictionary<int, int[]>();
        //Key：纵坐标；Value：横坐标范围
        var hor = new Dictionary<int, int[]>();
        foreach (var building in buildings)
        {
            var x = building[0];
            var y = building[1];
            if (ver.ContainsKey(x))
            {
                ver[x][0] = Math.Min(ver[x][0], y);
                ver[x][1] = Math.Max(ver[x][1], y);
            }
            else
            {
                ver.Add(x, [y, y]);
            }
            if (hor.ContainsKey(y))
            {
                hor[y][0] = Math.Min(hor[y][0], x);
                hor[y][1] = Math.Max(hor[y][1], x);
            }
            else
            {
                hor.Add(y, [x, x]);
            }
        }
        int res = 0;
        foreach (var building in buildings)
        {
            var x = building[0];
            var y = building[1];
            if (ver[x][0] < y && ver[x][1] > y && hor[y][0] < x && hor[y][1] > x)
            {
                res++;
            }
        }
        return res;
    }
}
// @lc code=end

