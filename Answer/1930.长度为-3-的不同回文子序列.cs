/*
 * @lc app=leetcode.cn id=1930 lang=csharp
 *
 * [1930] 长度为 3 的不同回文子序列
 */

// @lc code=start
public class Solution
{
    public int CountPalindromicSubsequence(string s)
    {
        var dic = new Dictionary<char, List<int>>();
        var res = new HashSet<string>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dic.ContainsKey(s[i]))
            {
                dic[s[i]].Add(i);
            }
            else
            {
                dic.Add(s[i], new List<int>() { i });
            }
        }
        foreach (var v in dic.Values)
        {
            if (v.Count >= 2)
            {
                var l = v[0];
                var r = v[v.Count - 1];

                for (int j = l + 1; j < r; j++)
                {
                    res.Add(string.Concat(s[l], s[j], s[r]));
                }
            }
        }
        return res.Count;
    }
}
// @lc code=end

