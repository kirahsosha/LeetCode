/*
 * @lc app=leetcode.cn id=14 lang=cpp
 *
 * [14] 最长公共前缀
 */

// @lc code=start
class Solution {
public:
    string longestCommonPrefix(vector<string>& strs) {
        int num = strs.size();
        if(num == 0) return "";
        if(num == 1) return strs[0];
        int i = 0, len = strs[0].length();
        string s(len, '\0');
        while(i < len)
        {
            for(int j = 1; j < num; j++)
            {
                if(i == strs[j].length() || strs[0][i] != strs[j][i])
                {
                    return s;
                }
            }
            s[i] = strs[0][i];
            i++;
        }
        return s;
    }
};
// @lc code=end

