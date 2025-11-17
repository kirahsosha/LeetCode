/*
 * @lc app=leetcode.cn id=387 lang=cpp
 *
 * [387] 字符串中的第一个唯一字符
 */

// @lc code=start
class Solution {
public:
    int firstUniqChar(string s) {
        if(s.length() == 0) return -1;
        if(s.length() == 1) return 0;
        for(int i = 0; i < s.length(); i++)
        {
            if(s[i] == '\0') continue;
            int k = 0;
            for(int j = i + 1; j < s.length(); j++)
            {
                if(s[i] == s[j])
                {
                    k = 1;
                    s[j] = '\0';
                }
            }
            if(k == 0) return i;
        }
        return -1;
    }
};
// @lc code=end

