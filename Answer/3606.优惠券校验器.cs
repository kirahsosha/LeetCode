/*
 * @lc app=leetcode.cn id=3606 lang=csharp
 *
 * [3606] 优惠券校验器
 */

// @lc code=start
using System.Text.RegularExpressions;
public class Solution
{
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        var res = new Dictionary<string, List<string>>
        {
            { "electronics", new List<string>() },
            { "grocery", new List<string>() },
            { "pharmacy", new List<string>() },
            { "restaurant", new List<string>() }
        };
        var n = code.Length;
        for (int i = 0; i < n; i++)
        {
            if (!isActive[i])
            {
                continue;
            }
            if (!res.ContainsKey(businessLine[i]))
            {
                continue;
            }
            if (!Regex.IsMatch(code[i], "^[a-zA-Z0-9_]+$"))
            {
                continue;
            }
            res[businessLine[i]].Add(code[i]);
        }
        var ans = new List<string>();
        foreach (var r in res.Values)
        {
            r.Sort(StringComparer.Ordinal);
            ans.AddRange(r);
        }
        return ans;
    }
}
// @lc code=end

