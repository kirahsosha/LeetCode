/*
 * @lc app=leetcode.cn id=1390 lang=csharp
 *
 * [1390] 四因数
 */

// @lc code=start
public class Solution
{
    public int SumFourDivisors(int[] nums)
    {
        var res = 0;
        foreach (var n in nums)
        {
            var di = AllDivisors(n);
            if (di.Length == 4)
            {
                res += di.Sum();
            }
        }
        return res;

        int[] AllDivisors(int n)
        {
            var res = new HashSet<int>();
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    res.Add(i);
                    res.Add(n / i);
                }
            }
            return res.ToArray();
        }
    }
}
// @lc code=end

