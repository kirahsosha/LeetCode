/*
 * @lc app=leetcode.cn id=190 lang=csharp
 *
 * [190] 颠倒二进制位
 */

// @lc code=start
public class Solution
{
    public int ReverseBits(int n)
    {
        uint res = (uint)n;
        res = ((res >> 1) & 0x55555555) | ((res & 0x55555555) << 1); // 01010101010101010101010101010101
        res = ((res >> 2) & 0x33333333) | ((res & 0x33333333) << 2); // 00110011001100110011001100110011
        res = ((res >> 4) & 0x0f0f0f0f) | ((res & 0x0f0f0f0f) << 4); // 00001111000011110000111100001111
        res = ((res >> 8) & 0x00ff00ff) | ((res & 0x00ff00ff) << 8); // 00000000111111110000000011111111
        res = (res >> 16) | (res << 16);
        return (int)res;
    }
}
// @lc code=end

