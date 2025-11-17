/*
 * @lc app=leetcode.cn id=125 lang=csharp
 *
 * [125] 验证回文串
 */

// @lc code=start
public class Solution {
    public bool IsPalindrome(string s) {
        s = s.ToLower().Trim();
        if (s.Length <= 1) return true;
        int i = 0, j = s.Length - 1;
        while(i <= j)
        {
            //i为非有效字符, i右移
            if(s[i] < 48 ||
              (s[i] > 57 && s[i] < 97) ||
               s[i] > 122)
            {
                i++;
                continue;
            }
            //j为非有效字符, j左移
            if(s[j] < 48 ||
              (s[j] > 57 && s[j] < 97) ||
               s[j] > 122)
            {
                j--;
                continue;
            }
            if(((s[i] >= 97 && s[i] <= 122) ||
                (s[i] >= 48 && s[i] <= 57)) &&
                 s[j] == s[i])
            {
                i++;
                j--;
                continue;
            }
            return false;
        }
        return true;
    }
}
// @lc code=end

