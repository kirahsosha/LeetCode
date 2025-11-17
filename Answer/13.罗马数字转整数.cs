/*
 * @lc app=leetcode.cn id=13 lang=csharp
 *
 * [13] 罗马数字转整数
 */

// @lc code=start
public class Solution
{
    int charToInt(char c)
    {
        switch (c)
        {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
        }

        return 0;
    }

    public int RomanToInt(string s)
    {
        int len = 0, x = 0, a = 0, b = 0;
        len = s.Length;
        if (len == 1) return charToInt(s[0]);
        for (int i = 0; i < (len - 1); i++)
        {
            a = charToInt(s[i]);
            b = charToInt(s[i + 1]);
            if (a < b) x -= a;
            else x += a;
        }

        a = charToInt(s[len - 1]);
        x += a;
        return x;
    }
}
// @lc code=end

