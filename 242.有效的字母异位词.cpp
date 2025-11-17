/*
 * @lc app=leetcode.cn id=242 lang=cpp
 *
 * [242] 有效的字母异位词
 */

// @lc code=start
class Solution {
public:
    bool isAnagram(string s, string t) {
        if(s.length() != t.length()) return false;
        if(s.length() == 0) return true;
        int si[26] = { 0 }, ti[26] = { 0 };
        for(int i = 0; i < s.length(); i++)
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
};
// @lc code=end

