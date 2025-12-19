/*
 * @lc app=leetcode.cn id=944 lang=csharp
 *
 * [944] 删列造序
 */

// @lc code=start
public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        var n = strs[0].Length;
        var res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][i] < strs[j - 1][i])
                {
                    res++;
                    break;
                }
            }
        }
        return res;
    }
}
// @lc code=end

