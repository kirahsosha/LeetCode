/*
 * @lc app=leetcode.cn id=2536 lang=csharp
 *
 * [2536] 子矩阵元素加 1
 */

// @lc code=start
public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        int[][] res = new int[n][];
        for (int i = 0; i < n; i++)
        {
            res[i] = new int[n];
        }

        foreach (var query in queries)
        {
            for (int i = query[0]; i <= query[2]; i++)
            {
                if (query[1] > 0)
                {
                    res[i][query[1] - 1]--;
                }
                res[i][query[3]]++;
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                res[i][j] += res[i][j + 1];
            }
        }

        return res;
    }
}
// @lc code=end

