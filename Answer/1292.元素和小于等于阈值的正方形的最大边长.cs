/*
 * @lc app=leetcode.cn id=1292 lang=csharp
 *
 * [1292] 元素和小于等于阈值的正方形的最大边长
 */

// @lc code=start
public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        var pre = new int[m][];
        for (int i = 0; i < m; i++)
        {
            pre[i] = new int[n + 1];
            for (int j = 0; j < n; j++)
            {
                pre[i][j + 1] = pre[i][j] + mat[i][j];
            }
        }
        int left = 0, right = Math.Min(m, n);
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;
            if (Check(mid))
            {
                left = mid;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;

        bool Check(int len)
        {
            for (int i = 0; i <= m - len; i++)
            {
                for (int j = 0; j <= n - len; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < len; k++)
                    {
                        sum += pre[i + k][j + len] - pre[i + k][j];
                    }
                    if (sum <= threshold)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
// @lc code=end

