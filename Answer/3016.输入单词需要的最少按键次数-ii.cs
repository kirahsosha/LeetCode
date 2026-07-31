/*
 * @lc app=leetcode.cn id=3016 lang=csharp
 *
 * [3016] 输入单词需要的最少按键次数 II
 */

// @lc code=start
public class Solution
{
    public int MinimumPushes(string word)
    {
        var n = word.Length;
        var count = new int[26];
        foreach (var c in word)
        {
            count[c - 'a']++;
        }
        Array.Sort(count, (a, b) => b.CompareTo(a));
        int ans = 0;
        for (int i = 0; i < 26 && count[i] > 0; i++)
        {
            ans += (i / 8 + 1) * count[i];
        }
        return ans;
    }
}
// @lc code=end

