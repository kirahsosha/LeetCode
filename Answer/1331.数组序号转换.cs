/*
 * @lc app=leetcode.cn id=1331 lang=csharp
 *
 * [1331] 数组序号转换
 */

// @lc code=start
public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int n = arr.Length;
        int[] sorted = new int[n];
        int[] idx = new int[n];
        for (int i = 0; i < n; i++)
        {
            sorted[i] = arr[i];
            idx[i] = i;
        }

        Array.Sort(sorted, idx);

        int[] result = new int[n];
        int rank = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || sorted[i] != sorted[i - 1])
            {
                rank++;
            }
            result[idx[i]] = rank;
        }
        return result;
    }
}
// @lc code=end
