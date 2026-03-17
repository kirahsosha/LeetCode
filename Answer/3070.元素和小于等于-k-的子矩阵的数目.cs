/*
 * @lc app=leetcode.cn id=3070 lang=csharp
 *
 * [3070] 元素和小于等于 k 的子矩阵的数目
 */

// @lc code=start
public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var pre = new int[n];
        var res = 0;
        for (var i = 0; i < m; i++)
        {
            var sum = 0;
            for (var j = 0; j < n; j++)
            {
                pre[j] += grid[i][j];
                sum += pre[j];
                if (sum <= k)
                {
                    res++;
                }
                else
                {
                    n = j;
                    break;
                }
            }
        }
        return res;
    }
}
// @lc code=end

