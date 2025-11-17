/*
 * @lc app=leetcode.cn id=389 lang=csharp
 *
 * [389] 找不同
 */

// @lc code=start
public class Solution {
    public char FindTheDifference(string s, string t) {
        int a = 0, b = 0;
        for(int i = 0; i < s.Length; i++)
        {
            a += (int)s[i];
            b += (int)t[i];
        }
        b += (int)t[s.Length];
        return (char)(b - a);
    }
}
// @lc code=end

