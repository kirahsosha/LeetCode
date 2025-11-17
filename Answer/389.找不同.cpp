/*
 * @lc app=leetcode.cn id=389 lang=cpp
 *
 * [389] 找不同
 */

// @lc code=start
class Solution {
public:
    char findTheDifference(string s, string t) {
        if(s.length() == 0) return t[0];
        int i = 0, j = 0, k = 0;
        while(i < t.length())
        {
            j = 0;
            k = 0;
            while(j < s.length())
            {
                if(t[i] == s[j])
                {
                    s[j] = '\0';
                    k = 1;
                    break;
                }
                j++;
            }
            if(k == 0) return t[i];
            i++;
        }
        return t[t.length() - 1];
    }
};
// @lc code=end

