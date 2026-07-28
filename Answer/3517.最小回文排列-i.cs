/*
 * @lc app=leetcode.cn id=3517 lang=csharp
 *
 * [3517] 最小回文排列 I
 */

// @lc code=start
public class Solution
{
    public string SmallestPalindrome(string s)
    {
        var count = new int[26];
        var n = s.Length;
        for (var i = 0; i < n / 2; i++)
        {
            count[s[i] - 'a']++;
        }
        var ans = new char[n];
        var left = 0;
        var right = n - 1;
        for (var i = 0; i < 26; i++)
        {
            while (count[i] > 0)
            {
                char c = (char)(i + 'a');
                ans[left++] = c;
                ans[right--] = c;
                count[i]--;
            }
        }
        if (n % 2 == 1)
        {
            ans[left] = s[n / 2];
        }
        return new string(ans);
    }
}
// @lc code=end

