/*
 * @lc app=leetcode.cn id=345 lang=cpp
 *
 * [345] 反转字符串中的元音字母
 */

// @lc code=start
class Solution {
public:
    string reverseVowels(string s) {
        if(s.length() < 2) return s;
        char c;
        int i = 0, j = s.length() - 1;
        while(i < j)
        {
            if((tolower(s[i]) == 'a' ||
                tolower(s[i]) == 'e' ||
                tolower(s[i]) == 'i' ||
                tolower(s[i]) == 'o' ||
                tolower(s[i]) == 'u') &&
               (tolower(s[j]) == 'a' ||
                tolower(s[j]) == 'e' ||
                tolower(s[j]) == 'i' ||
                tolower(s[j]) == 'o' ||
                tolower(s[j]) == 'u'))
            {
                c = s[i];
                s[i] = s[j];
                s[j] = c;
                i++;
                j--;
            }
            else if(tolower(s[i]) == 'a' ||
                    tolower(s[i]) == 'e' ||
                    tolower(s[i]) == 'i' ||
                    tolower(s[i]) == 'o' ||
                    tolower(s[i]) == 'u')
            {
                j--;
            }
            else if(tolower(s[j]) == 'a' ||
                    tolower(s[j]) == 'e' ||
                    tolower(s[j]) == 'i' ||
                    tolower(s[j]) == 'o' ||
                    tolower(s[j]) == 'u')
            {
                i++;
            }
            else
            {
                i++;
                j--;
            }
        }
        return s;
    }
};
// @lc code=end

