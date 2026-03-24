/*
 * @lc app=leetcode.cn id=3567 lang=csharp
 *
 * [3567] 子矩阵的最小绝对差
 */

// @lc code=start
public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var rows = m - k + 1;
        var cols = n - k + 1;
        var result = new int[rows][];
        for (var i = 0; i < rows; i++)
        {
            result[i] = new int[cols];
            for (var j = 0; j < cols; j++)
            {
                var uniqueVals = new HashSet<int>();
                for (var x = i; x < i + k; x++)
                {
                    for (var y = j; y < j + k; y++)
                    {
                        uniqueVals.Add(grid[x][y]);
                    }
                }
                if (uniqueVals.Count == 1)
                {
                    result[i][j] = 0;
                    continue;
                }
                var sortedVals = new List<int>(uniqueVals);
                sortedVals.Sort();
                var minDiff = int.MaxValue;
                for (var idx = 1; idx < sortedVals.Count; idx++)
                {
                    var diff = sortedVals[idx] - sortedVals[idx - 1];
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                    }
                }
                result[i][j] = minDiff;
            }
        }
        return result;
    }
}
// @lc code=end

