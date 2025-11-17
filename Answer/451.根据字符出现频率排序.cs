/*
 * @lc app=leetcode.cn id=451 lang=csharp
 *
 * [451] 根据字符出现频率排序
 */

// @lc code=start
public class Solution {
    public string FrequencySort(string s) {
        if (s == null || s.Length <= 2) return s;
        var dic = s.GroupBy(p => p).OrderByDescending(p => p.Count());
        string ans = "";
        foreach (var item in dic)
        {
            ans += string.Concat(item.ToArray());
        }
        return ans;
    }
}
// @lc code=end

