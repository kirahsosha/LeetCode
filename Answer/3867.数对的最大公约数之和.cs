/*
 * @lc app=leetcode.cn id=3867 lang=csharp
 *
 * [3867] 数对的最大公约数之和
 */

// @lc code=start
public class Solution
{
    public long GcdSum(int[] nums)
    {
        var n = nums.Length;
        var gcds = new int[n];
        var max = 0;
        for (var i = 0; i < n; i++)
        {
            var v = nums[i];
            if (v > max)
            {
                max = v;
            }
            gcds[i] = Gcd(v, max);
        }

        Array.Sort(gcds);

        long ans = 0;
        for (var i = 0; i < n / 2; i++)
        {
            ans += Gcd(gcds[i], gcds[n - 1 - i]);
        }
        return ans;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = a % b;
            a = b;
            b = t;
        }
        return a;
    }
}
// @lc code=end
