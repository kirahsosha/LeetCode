/*
 * @lc app=leetcode.cn id=168 lang=cpp
 *
 * [168] Excel表列名称
 */

// @lc code=start
class Solution {
public:
    string convertToTitle(int n) {
        string s = "";
        while(n != 0)
        {
            char c = (char)((n - 1) % 26 + 65);
            n = (n - 1) / 26;
            s = c + s;
        }
        return s;
    }
};
// @lc code=end

