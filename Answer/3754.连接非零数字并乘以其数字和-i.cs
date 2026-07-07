/*
 * @lc app=leetcode.cn id=3754 lang=csharp
 *
 * [3754] 连接非零数字并乘以其数字和 I
 */

// @lc code=start
public class Solution
{
    public long SumAndMultiply(int n)
    {
        int x = 0;
        int pow = 1;
        int sum = 0;
        while (n > 0)
        {
            int d = n % 10;
            if (d != 0)
            {
                x += d * pow;
                pow *= 10;
                sum += d;
            }
            n /= 10;
        }
        return (long)x * sum;
    }
}
// @lc code=end
