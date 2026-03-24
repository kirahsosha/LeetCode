/*
 * @lc app=leetcode.cn id=1886 lang=csharp
 *
 * [1886] 判断矩阵经轮转后是否一致
 */

// @lc code=start
public class Solution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        var n = mat.Length;
        var res1 = true;
        var res2 = true;
        var res3 = true;
        var res4 = true;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (res1)
                {
                    if (mat[i][j] != target[i][j])
                    {
                        res1 = false;
                    }
                }
                if (res2)
                {
                    if (mat[i][j] != target[j][n - i - 1])
                    {
                        res2 = false;
                    }
                }
                if (res3)
                {
                    if (mat[i][j] != target[n - i - 1][n - j - 1])
                    {
                        res3 = false;
                    }
                }
                if (res4)
                {
                    if (mat[i][j] != target[n - j - 1][i])
                    {
                        res4 = false;
                    }
                }
            }
        }
        return res1 || res2 || res3 || res4;
    }
}
// @lc code=end

