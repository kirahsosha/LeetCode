/*
 * @lc app=leetcode.cn id=680 lang=csharp
 *
 * [680] 验证回文字符串 Ⅱ
 */

// @lc code=start
public class Solution {
    public bool checkPalindrome(string s)
    {
        if(s.Length <= 1) return true;
        int i = 0, j = s.Length - 1;
        while(i <= j)
        {
            if(s[j] == s[i])
            {
                i++;
                j--;
                continue;
            }
            return false;
        }
        return true;
    }

    public bool ValidPalindrome(string s) {
        if(s.Length <= 2) return true;
        int i = 0, j = s.Length - 1;
        bool k = false;
        while(i <= j)
        {
            if(s[j] == s[i])
            {
                i++;
                j--;
                continue;
            }
            else if(!k)
            {
                if(checkPalindrome(s.Substring(i + 1, j - i)))
                {
                    return true;
                }
                if(checkPalindrome(s.Substring(i, j - i)))
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }
}
// @lc code=end

