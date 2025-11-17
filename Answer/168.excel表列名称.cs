/*
 * @lc app=leetcode.cn id=168 lang=csharp
 *
 * [168] Excel表列名称
 */

// @lc code=start
public class Solution {

    public char ItoC(int i)
    {
        char c;
        c = (char)(i + 64);
        return c;
    }
    public string ConvertToTitle(int n) {
        string s = "";
        while(n != 0)
        {
            char c = (char)((n - 1) % 26 + 65);
            n = (n - 1) / 26;
            s = c + s;
        }
        return s;
    }
}
// @lc code=end

