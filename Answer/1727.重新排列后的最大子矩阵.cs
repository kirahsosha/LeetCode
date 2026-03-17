/*
 * @lc app=leetcode.cn id=1727 lang=csharp
 *
 * [1727] 重新排列后的最大子矩阵
 */

// @lc code=start
public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var heights = new int[n];
        var idx = new int[n]; // 按照高度排序后的列号
        for (int i = 0; i < n; i++)
        {
            idx[i] = i;
        }
        var nonZeros = new int[n]; // 避免在循环内反复申请内存
        var res = 0;

        foreach (var row in matrix)
        {
            int p = 0;
            int q = 0;
            foreach (var j in idx)
            {
                if (row[j] == 0)
                {
                    heights[j] = 0;
                    idx[p++] = j; // 高度 0 排在前面
                }
                else
                {
                    heights[j]++;
                    nonZeros[q++] = j;
                }
            }

            // heights[idx[i]] 是递增的
            for (int i = p; i < n; i++)
            { // 高度 0 无需计算
                idx[i] = nonZeros[i - p]; // 把 nonZeros 复制到 idx 的 [p,n-1] 中
                res = Math.Max(res, (n - i) * heights[idx[i]]);
            }
        }
        return res;
    }
}
// @lc code=end

