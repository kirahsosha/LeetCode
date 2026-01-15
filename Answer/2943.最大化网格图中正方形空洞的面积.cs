/*
 * @lc app=leetcode.cn id=2943 lang=csharp
 *
 * [2943] 最大化网格图中正方形空洞的面积
 */

// @lc code=start
public class Solution
{
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
    {
        Array.Sort(hBars);
        var hMax = 1;
        var left = 1;
        var right = 2;
        foreach (var bar in hBars)
        {
            if (bar == right)
            {
                right = bar + 1;
            }
            else
            {
                left = bar - 1;
                right = bar + 1;
            }
            hMax = Math.Max(hMax, right - left);
        }

        Array.Sort(vBars);
        var vMax = 1;
        left = 1;
        right = 2;
        foreach (var bar in vBars)
        {
            if (bar == right)
            {
                right = bar + 1;
            }
            else
            {
                left = bar - 1;
                right = bar + 1;
            }
            vMax = Math.Max(vMax, right - left);
        }
        var l = Math.Min(hMax, vMax);
        return l * l;
    }
}
// @lc code=end

