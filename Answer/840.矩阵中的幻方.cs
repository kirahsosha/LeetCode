/*
 * @lc app=leetcode.cn id=840 lang=csharp
 *
 * [840] 矩阵中的幻方
 */

// @lc code=start
public class Solution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        var n = grid.Length;
        var m = grid[0].Length;
        var res = 0;
        var target = 15;
        for (int i = 0; i <= n - 3; i++)
        {
            for (int j = 0; j <= m - 3; j++)
            {
                if (IsMagicSquare(i, j))
                {
                    res++;
                }
            }
        }
        return res;

        bool IsMagicSquare(int x, int y)
        {
            var seen = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var val = grid[x + i][y + j];
                    if (val < 1 || val > 9 || seen.Contains(val))
                    {
                        return false;
                    }
                    seen.Add(val);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                var rowSum = 0;
                var colSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    rowSum += grid[x + i][y + j];
                    colSum += grid[x + j][y + i];
                }
                if (rowSum != target || colSum != target)
                {
                    return false;
                }
            }
            var diag1 = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2];
            var diag2 = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y];
            if (diag1 != target || diag2 != target)
            {
                return false;
            }
            return true;
        }
    }
}
// @lc code=end

