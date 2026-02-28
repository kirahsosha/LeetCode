/*
 * @lc app=leetcode.cn id=1680 lang=csharp
 *
 * [1680] 连接连续二进制数字
 */

// @lc code=start
public class Solution
{
    public int ConcatenatedBinary(int n)
    {
        const uint MOD = 1000000007;
        uint res = 0;
        for (uint i = 1; i <= n; i++)
        {
            uint t = i;
            while (t > 0)
            {
                t >>= 1;
                res = (res << 1) % MOD;
            }
            res = (res + i) % MOD;
        }
        return (int)res;
    }
}
// @lc code=end

