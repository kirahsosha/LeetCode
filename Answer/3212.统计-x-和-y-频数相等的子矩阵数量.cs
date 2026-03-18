/*
 * @lc app=leetcode.cn id=3212 lang=csharp
 *
 * [3212] 统计 X 和 Y 频数相等的子矩阵数量
 */

// @lc code=start
public class Solution
{
    public int NumberOfSubmatrices(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var cntX = new int[n];
        var cntY = new int[n];
        var res = 0;
        for (var i = 0; i < m; i++)
        {
            var sumX = 0;
            var sumY = 0;
            for (var j = 0; j < n; j++)
            {
                cntX[j] += grid[i][j] == 'X' ? 1 : 0;
                cntY[j] += grid[i][j] == 'Y' ? 1 : 0;
                sumX += cntX[j];
                sumY += cntY[j];
                if (sumX == sumY && sumX > 0)
                {
                    res++;
                }
            }
        }
        return res;
    }
}
// @lc code=end

