/*
 * @lc app=leetcode.cn id=165 lang=csharp
 *
 * [165] 比较版本号
 */

// @lc code=start
public class Solution
{
    public int CompareVersion(string version1, string version2)
    {
        string[] s1 = version1.Split('.');
        string[] s2 = version2.Split('.');
        int len = Math.Max(s1.Length, s2.Length);
        for (int i = 0; i < len; i++)
        {
            int v1 = 0;
            if (s1.Length > i)
            {
                v1 = int.Parse(s1[i]);
            }
            int v2 = 0;
            if (s2.Length > i)
            {
                v2 = int.Parse(s2[i]);
            }

            if (v1 > v2)
            {
                return 1;
            }

            if (v1 < v2)
            {
                return -1;
            }
        }

        return 0;
    }
}
// @lc code=end

