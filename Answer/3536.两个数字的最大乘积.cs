/*
 * @lc app=leetcode.cn id=3536 lang=csharp
 *
 * [3536] 两个数字的最大乘积
 */

// @lc code=start
public class Solution
{
    public int MaxProduct(int n)
    {
        var digit = 0;
        var ans = 0;
        while (n > 0)
        {
            var d = n % 10;
            ans = Math.Max(ans, d * digit);
            digit = Math.Max(d, digit);
            n = n / 10;
        }
        return ans;
    }
}
// @lc code=end

