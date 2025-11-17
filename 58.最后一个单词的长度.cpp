/*
 * @lc app=leetcode.cn id=58 lang=cpp
 *
 * [58] 最后一个单词的长度
 */

// @lc code=start
class Solution {
public:
    int lengthOfLastWord(string s) {
        if (s.length() == 0) return 0;
        if (s == " ") return 0;
        int l = 0, ol = 0;
        for (int i = 0; i < s.length(); i++)
        {
            if (s[i] == ' ')
            {
                ol = l != 0 ? l : ol;
                l = 0;
            }
            else
            {
                l++;
            }
        }
        return l == 0 ? ol : l;
    }
};
// @lc code=end

