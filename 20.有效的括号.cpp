/*
 * @lc app=leetcode.cn id=20 lang=cpp
 *
 * [20] 有效的括号
 */

// @lc code=start
class Solution {
public:
    bool isValid(string s) {
        if(s == "") return true;
        if(s.length() % 2 != 0) return false;
        string st(s.length(), '\0');
        st[0] = s[0];
        int i = 0, j = 1;
        while(j < s.length())
        {
            if(i == -1)
            {
                i = 0;
                st[i] = s[j];
                j++;
            }
            if(i > s.length() / 2) return false;
            if((st[i] == '(' && s[j] == ')') ||
               (st[i] == '[' && s[j] == ']') ||
               (st[i] == '{' && s[j] == '}'))
            {
                i--;
            }
            else if(s[j] == '(' ||
                    s[j] == '[' ||
                    s[j] == '{')
            {
                st[++i] = s[j];
            }
            else
            {
                return false;
            }
            j++;
        }
        if(i == -1) return true;
        return false;
    }
};
// @lc code=end

