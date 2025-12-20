/*
 * @lc app=leetcode.cn id=955 lang=csharp
 *
 * [955] 删列造序 II
 */

// @lc code=start
public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int n = strs.Length;
        int m = strs[0].Length;
        var cuts = new bool[n - 1];

        int ans = 0;
        for (int j = 0; j < m; j++)
        {
            var check = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (!cuts[i] && strs[i][j] > strs[i + 1][j])
                {
                    ans++;
                    check = false;
                    break;
                }
            }
            if (check)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (strs[i][j] < strs[i + 1][j])
                    {
                        cuts[i] = true;
                    }
                }
            }
        }

        return ans;
    }
}
// @lc code=end

