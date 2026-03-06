/*
 * @lc app=leetcode.cn id=1784 lang=csharp
 *
 * [1784] 检查二进制字符串字段
 */

// @lc code=start
public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        var res = false;
        var hasZero = false;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '1' && !res)
            {
                res = true;
            }
            else if (s[i] == '0' && res)
            {
                hasZero = true;
            }
            else if (s[i] == '1' && hasZero)
            {
                return false;
            }
        }
        return res;
    }
}
// @lc code=end

