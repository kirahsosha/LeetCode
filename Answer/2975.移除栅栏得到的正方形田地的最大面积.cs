/*
 * @lc app=leetcode.cn id=2975 lang=csharp
 *
 * [2975] 移除栅栏得到的正方形田地的最大面积
 */

// @lc code=start
public class Solution
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        int MOD = 1000000007;
        Array.Sort(hFences);
        var hLength = new HashSet<int>() { m - 1 };
        for (int i = 0; i < hFences.Length; i++)
        {
            hLength.Add(hFences[i] - 1);
            hLength.Add(m - hFences[i]);
            for (int j = i + 1; j < hFences.Length; j++)
            {
                hLength.Add(hFences[j] - hFences[i]);
            }
        }

        Array.Sort(vFences);
        var vLength = new HashSet<int>() { n - 1 };
        for (int i = 0; i < vFences.Length; i++)
        {
            vLength.Add(vFences[i] - 1);
            vLength.Add(n - vFences[i]);
            for (int j = i + 1; j < vFences.Length; j++)
            {
                vLength.Add(vFences[j] - vFences[i]);
            }
        }

        long res = 0;
        foreach (var len in hLength)
        {
            if (vLength.Contains(len))
            {
                res = Math.Max(res, len);
            }
        }

        if (res == 0)
        {
            return -1;
        }
        else
        {
            return (int)(res * res % MOD);
        }
    }
}
// @lc code=end

