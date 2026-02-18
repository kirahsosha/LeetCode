/*
 * @lc app=leetcode.cn id=693 lang=csharp
 *
 * [693] 交替位二进制数
 */

// @lc code=start
public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        uint un = (uint)n;
        var a = un ^ (un >> 1);
        var b = a + 1;
        return (a & b) == 0;
    }
}
// @lc code=end

