/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
public class Solution {
    public bool IsValid(string s) {
        if(s == "") return true;
        if(s.Length % 2 != 0) return false;
        char[] st = new char[s.Length];
        st[0] = s[0];
        int i = 0, j = 1;
        while(j < s.Length)
        {
            if(i == -1)
            {
                i = 0;
                st[i] = s[j];
                j++;
            }
            if(i > s.Length / 2) return false;
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
}
// @lc code=end

