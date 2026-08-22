/*
 * @lc app=leetcode.cn id=3345 lang=csharp
 *
 * [3345] 最小可整除数位乘积 I
 */

// @lc code=start
public class Solution
{
    public int SmallestNumber(int n, int t)
    {
        while (n > 0)
        {
            var temp = n;
            var ans = 1;
            while (temp > 0)
            {
                ans *= temp % 10;
                temp /= 10;
            }
            if (ans % t == 0)
            {
                return n;
            }
            n++;
        }
        return n;
    }
}
// @lc code=end

