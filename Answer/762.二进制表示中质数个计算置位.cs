/*
 * @lc app=leetcode.cn id=762 lang=csharp
 *
 * [762] 二进制表示中质数个计算置位
 */

// @lc code=start
public class Solution
{
    public int CountPrimeSetBits(int left, int right)
    {
        int BitCount(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }

        int ans = 0;
        for (int x = left; x <= right; ++x)
        {
            if (((1 << BitCount(x)) & 665772) != 0)
            {
                ++ans;
            }
        }
        return ans;
    }
}
// @lc code=end

