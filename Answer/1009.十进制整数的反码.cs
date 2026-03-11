/*
 * @lc app=leetcode.cn id=1009 lang=csharp
 *
 * [1009] 十进制整数的反码
 */

// @lc code=start
public class Solution
{
    public int BitwiseComplement(int n)
    {
        if (n == 0) return 1;
        var num = (uint)n;
        var bits = 0;
        while (num > 0)
        {
            num >>= 1;
            bits++;
        }

        var mask = (1 << bits) - 1;
        return n ^ mask;
    }
}
// @lc code=end

