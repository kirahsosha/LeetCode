/*
 * @lc app=leetcode.cn id=49 lang=csharp
 *
 * [49] 字母异位词分组
 */

// @lc code=start
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dic = new Dictionary<string, List<string>>();
        foreach(var str in strs)
        {
            var sortedStr = new string(str.OrderBy(c => c).ToArray());
            if (dic.ContainsKey(sortedStr))
            {
                dic[sortedStr].Add(str);
            }
            else
            {
                dic.Add(sortedStr, new List<string> { str });
            }
        }
        return dic.Select(p=>p.Value).Cast<IList<string>>().ToList();
    }
}
// @lc code=end

