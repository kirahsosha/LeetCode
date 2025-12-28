/*
 * @lc app=leetcode.cn id=1351 lang=csharp
 *
 * [1351] 统计有序矩阵中的负数
 */

// @lc code=start
public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var ans = 0;
        var j = 0;
        for (int i = m - 1; i >= 0; i--)
        {
            while (j < n)
            {
                if (grid[i][j] < 0)
                {
                    ans += n - j;
                    break;
                }
                j++;
            }
        }
        return ans;
    }
}
// @lc code=end

