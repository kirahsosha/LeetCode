/*
 * @lc app=leetcode.cn id=960 lang=csharp
 *
 * [960] 删列造序 III
 */

// @lc code=start
public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int m = strs[0].Length;
        int[] f = new int[m];
        int maxF = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (f[j] > f[i] && LessEq(strs, j, i))
                {
                    f[i] = f[j];
                }
            }
            f[i]++;
            maxF = Math.Max(maxF, f[i]);
        }
        return m - maxF;
    }

    private bool LessEq(string[] strs, int j, int i)
    {
        foreach (var s in strs)
        {
            if (s[j] > s[i])
            {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

