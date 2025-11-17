/*
 * @lc app=leetcode.cn id=344 lang=cpp
 *
 * [344] 反转字符串
 */

// @lc code=start
class Solution {
public:
    void reverseString(vector<char>& s) {
        if(s.size() < 2) return;
        char c;
        int i = 0, j = s.size() - 1;
        while(i < j)
        {
            c = s[i];
            s[i] = s[j];
            s[j] = c;
            i++;
            j--;
        }
        return;
    }
};
// @lc code=end

