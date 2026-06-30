/*
 * @lc app=leetcode.cn id=1358 lang=csharp
 *
 * [1358] 包含所有三种字符的子字符串数目
 */

// @lc code=start
public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int[] last = new int[3] { -1, -1, -1 };
        int ans = 0;
        for (int i = 0; i < s.Length; i++)
        {
            last[s[i] - 'a'] = i;
            ans += Math.Min(last[0], Math.Min(last[1], last[2])) + 1;
        }
        return ans;
    }
}
// @lc code=end
