/*
 * @lc app=leetcode.cn id=1545 lang=csharp
 *
 * [1545] 找出第 N 个二进制字符串中的第 K 位
 */

// @lc code=start
public class Solution
{
    public char FindKthBit(int n, int k)
    {
        //数学
        if (k % 2 > 0)
        {
            //奇数
            return (char)('0' + k / 2 % 2);
        }
        else
        {
            //偶数
            k /= k & -k; // 去掉 k 的尾零
            return (char)('1' - k / 2 % 2);
        }
    }
}
// @lc code=end

