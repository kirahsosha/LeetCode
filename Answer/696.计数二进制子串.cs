/*
 * @lc app=leetcode.cn id=696 lang=csharp
 *
 * [696] 计数二进制子串
 */

// @lc code=start
public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        var a = '0';
        var count = 0;
        var old = 0;
        var res = 0;
        foreach (var c in s)
        {
            if (c == a)
            {
                count++;
            }
            else
            {
                res += Math.Min(old, count);
                old = count;
                a = c;
                count = 1;
            }
        }
        res += Math.Min(old, count);
        return res;
    }
}
// @lc code=end

