/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
public class Solution
{
    public string LongestPalindrome(string s)
    {
        int n = s.Length;
        if (n <= 1) return s;
        bool[,] dp = new bool[n, n];
        string res = "";
        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i + len - 1 < n; i++)
            {
                int j = i + len - 1;
                if (len == 1)
                {
                    dp[i, j] = true;
                }
                else if (len == 2)
                {
                    dp[i, j] = s[i] == s[j];
                }
                else
                {
                    dp[i, j] = dp[i + 1, j - 1] && s[i] == s[j];
                }
                if (len > res.Length && dp[i, j])
                {
                    res = s.Substring(i, len);
                }
            }
        }
        return res;
    }
}
// @lc code=end

