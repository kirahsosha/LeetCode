/*
 * @lc app=leetcode.cn id=242 lang=csharp
 *
 * [242] 有效的字母异位词
 */

// @lc code=start
public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;
        if(s.Length == 0) return true;
        int[] si = new int[26];
        int[] ti = new int[26];
        for(int i = 0; i < s.Length; i++)
        {
            si[(int)s[i] - 97]++;
            ti[(int)t[i] - 97]++;
        }
        for(int i = 0; i < 26; i++)
        {
            if(si[i] != ti[i]) return false;
        }
        return true;
    }
}
// @lc code=end

