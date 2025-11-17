/*
 * @lc app=leetcode.cn id=28 lang=cpp
 *
 * [28] 实现 strStr()
 */

// @lc code=start
class Solution {
public:
    int strStr(string haystack, string needle) {
        if(needle == "") return 0;
        if(haystack == "") return -1;
        if(needle.length() > haystack.length()) return -1;
        int len = haystack.length() - needle.length() + 1;
        int i = 0, h = 0, n = 0;
        while(i < len)
        {
            if(needle[0] == haystack[i])
            {
                n = 0;
                h = i;
                while(n < needle.length())
                {
                    if(needle[n] != haystack[h]) break;
                    n++;
                    h++;
                }
                if(n == needle.length()) return i;
            }
            i++;
        }
        return -1;
    }
};
// @lc code=end

