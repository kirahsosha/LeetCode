/*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 */

// @lc code=start
public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var ns = p + s;
        var res = new List<int>();
        var cs = p.ToList();
        var lostChar = cs.Distinct().Select(c => new KeyValuePair<char, int>(c, 0)).ToDictionary(p => p.Key, p => p.Value);
        for (int i = 0; i < s.Length; i++)
        {
            //移除前一个字符
            cs.Remove(ns[i]);
            //添加后一个字符
            cs.Add(ns[i + p.Length]);
            //前一个字符符合条件时添加
            if (lostChar.ContainsKey(ns[i]))
            {
                lostChar[ns[i]]++;
            }
            //后一个字符符合条件时移除
            if (lostChar.ContainsKey(ns[i + p.Length]))
            {
                lostChar[ns[i + p.Length]]--;
            }
            if (lostChar.Values.All(p => p == 0) && i + 1 - p.Length >= 0)
            {
                res.Add(i + 1 - p.Length);
            }
        }
        return res;
    }
}
// @lc code=end

