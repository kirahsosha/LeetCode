/*
 * @lc app=leetcode.cn id=1758 lang=csharp
 *
 * [1758] 生成交替二进制字符串的最少操作数
 */

// @lc code=start
public class Solution
{
    public int MinOperations(string s)
    {
        var res0 = 0;
        var res1 = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] - '0' != i % 2)
            {
                res0++;
            }
            else
            {
                res1++;
            }
        }
        return Math.Min(res0, res1);
    }
}
// @lc code=end

