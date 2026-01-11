/*
 * @lc app=leetcode.cn id=1266 lang=csharp
 *
 * [1266] 访问所有点的最小时间
 */

// @lc code=start
public class Solution
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        var n = points.Length;
        if (n == 1) return 0;
        var res = 0;
        var x1 = points[0][0];
        var y1 = points[0][1];
        for (int i = 1; i < n; i++)
        {
            var x = points[i][0];
            var y = points[i][1];
            res += Math.Max(Math.Abs(x - x1), Math.Abs(y - y1));
            x1 = x;
            y1 = y;
        }
        return res;
    }
}
// @lc code=end

