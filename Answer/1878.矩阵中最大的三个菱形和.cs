/*
 * @lc app=leetcode.cn id=1878 lang=csharp
 *
 * [1878] 矩阵中最大的三个菱形和
 */

// @lc code=start
public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        // preD1[i][j]: prefix sum along '\' diagonal ending at (i,j)
        var preD1 = new int[m][];
        // preD2[i][j]: prefix sum along '/' diagonal ending at (i,j) (from top-right)
        var preD2 = new int[m][];
        for (var i = 0; i < m; i++)
        {
            preD1[i] = new int[n];
            preD2[i] = new int[n];
            for (var j = 0; j < n; j++)
            {
                preD1[i][j] = grid[i][j] + (i > 0 && j > 0 ? preD1[i - 1][j - 1] : 0);
                preD2[i][j] = grid[i][j] + (i > 0 && j < n - 1 ? preD2[i - 1][j + 1] : 0);
            }
        }

        // Sum along '\' from (i1,j1) to (i2,j2)
        int SumD1(int i1, int j1, int i2, int j2) =>
            preD1[i2][j2] - (i1 > 0 && j1 > 0 ? preD1[i1 - 1][j1 - 1] : 0);

        // Sum along '/' from (i1,j1) to (i2,j2), where i1 <= i2
        int SumD2(int i1, int j1, int i2, int j2) =>
            preD2[i2][j2] - (i1 > 0 && j1 < n - 1 ? preD2[i1 - 1][j1 + 1] : 0);

        var top3 = new SortedSet<int>();
        for (var r = 0; r < m; r++)
        {
            for (var c = 0; c < n; c++)
            {
                // k=0: single cell
                top3.Add(grid[r][c]);
                if (top3.Count > 3) top3.Remove(top3.Min);

                var maxK = Math.Min(Math.Min(r, m - 1 - r), Math.Min(c, n - 1 - c));
                for (var k = 1; k <= maxK; k++)
                {
                    // 4 boundary sides (each inclusive of both endpoints, then subtract 4 corners)
                    // Top->Right along '\'
                    // Right->Bottom along '/'
                    // Left->Bottom along '\'
                    // Top->Left along '/'
                    var sum = SumD1(r - k, c, r, c + k)
                            + SumD2(r, c + k, r + k, c)
                            + SumD1(r, c - k, r + k, c)
                            + SumD2(r - k, c, r, c - k)
                            - grid[r - k][c] - grid[r][c + k]
                            - grid[r + k][c] - grid[r][c - k];
                    top3.Add(sum);
                    if (top3.Count > 3) top3.Remove(top3.Min);
                }
            }
        }

        return [.. top3.OrderByDescending(x => x)];
    }
}
// @lc code=end

