/*
 * @lc app=leetcode.cn id=1967 lang=csharp
 *
 * [1967] 作为子字符串出现在单词中的字符串数目
 */

using System;

// @lc code=start
public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        int ans = 0;
        foreach (string pattern in patterns)
        {
            if (word.Contains(pattern, StringComparison.Ordinal))
            {
                ans++;
            }
        }
        return ans;
    }
}
// @lc code=end
