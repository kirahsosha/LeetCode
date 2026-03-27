/*
 * @lc app=leetcode.cn id=2946 lang=csharp
 *
 * [2946] 循环移位后的矩阵相似检查
 */

// @lc code=start
public class Solution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        k %= n;
        if (k == 0) return true;

        for (int i = 0; i < m; i++)
        {
            int[] row = mat[i];
            if ((i & 1) == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    if (row[j] != row[(j + k) % n])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = 0; j < n; j++)
                {
                    if (row[j] != row[(j - k + n) % n])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
// @lc code=end

