/*
 * @lc app=leetcode.cn id=73 lang=csharp
 *
 * [73] 矩阵置零
 */

// @lc code=start
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var a = 1;
        var b = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    if (i == 0)
                    {
                        a = 0;
                    }
                    if (j == 0)
                    {
                        b = 0;
                    }
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }
        for (int i = 1; i < m; i++)
        {
            if (matrix[i][0] == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }
        for (int j = 1; j < n; j++)
        {
            if (matrix[0][j] == 0)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][j] = 0;
                }
            }
        }
        if (a == 0)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[0][j] = 0;
            }
        }
        if (b == 0)
        {
            for (int i = 0; i < m; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
}
// @lc code=end

