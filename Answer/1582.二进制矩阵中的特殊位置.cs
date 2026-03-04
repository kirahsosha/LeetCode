/*
 * @lc app=leetcode.cn id=1582 lang=csharp
 *
 * [1582] 二进制矩阵中的特殊位置
 */

// @lc code=start
public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var rows = new int[m];
        var res = 0;
        for (var i = 0; i < m; i++)
        {
            var first = -1;
            for (var j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    rows[i] = j;
                    if (first == -1)
                    {
                        first = j;
                    }
                }
            }
            if (first == rows[i])
            {
                var a = -1;
                var b = -1;
                for (var j = 0; j < m; j++)
                {
                    if (mat[j][first] == 1)
                    {
                        if (a == -1)
                        {
                            a = j;
                        }
                        else
                        {
                            b = j;
                            break;
                        }
                    }
                }
                if (a != -1 && b == -1) res++;
            }
        }
        return res;
    }
}
// @lc code=end

