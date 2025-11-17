/*
 * @lc app=leetcode.cn id=171 lang=cpp
 *
 * [171] Excel表列序号
 */

// @lc code=start
class Solution {
public:
    int titleToNumber(string s) {
        if(s.length() == 0) return 0;
        int n = 0;
        for(int i = 0; i < s.length(); i++)
        {
            n += ((int)s[i] - 64) * pow(26, (s.length() - i - 1));
        }
        return n;
    }
};
// @lc code=end

