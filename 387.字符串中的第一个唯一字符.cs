/*
 * @lc app=leetcode.cn id=387 lang=csharp
 *
 * [387] 字符串中的第一个唯一字符
 */

// @lc code=start
public class Solution {
    public int FirstUniqChar(string s) {
        if(s.Length == 0) return -1;
        if(s.Length == 1) return 0;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '0') continue;
            int k = 0;
            for(int j = i + 1; j < s.Length; j++)
            {
                if(s[i] == s[j])
                {
                    k = 1;
                }
            }
            if(k == 0) return i;
            s = s.Replace(s[i], '0');
        }
        return -1;
    }
}
// @lc code=end

