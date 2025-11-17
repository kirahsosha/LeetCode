/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length == 0) return 0;
        if(s.Length == 1) return 1;
        int l = 0, r = 1;
        IList<char> list = new List<char>{};
        list.Add(s[0]);
        int ans = 1;
        while(r < s.Length)
        {
            while(list.Contains(s[r]) && l < r)
            {
                list.Remove(s[l++]);
            }
            list.Add(s[r]);
            ans = Math.Max(ans, list.Count());
            r++;
        }
        return ans;
    }
}
// @lc code=end

