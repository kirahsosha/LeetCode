/*
 * @lc app=leetcode.cn id=171 lang=csharp
 *
 * [171] Excel表列序号
 */

// @lc code=start
public class Solution {
    public int TitleToNumber(string s) {
        if (s.Length == 0) return 0;
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            n += (int)(((int)s[i] - 64) * Math.Pow(26, (s.Length - i - 1)));
        }
        return n;
    }
}
// @lc code=end

