/*
 * @lc app=leetcode.cn id=1015 lang=csharp
 *
 * [1015] 可被 K 整除的最小整数
 */

// @lc code=start
public class Solution
{
    public int SmallestRepunitDivByK(int k)
    {
        var set = new HashSet<int>();
        var n = 0;
        for (int i = 1; i <= k; i++)
        {
            n = (n * 10 + 1) % k;
            if (n == 0)
            {
                return i;
            }
            else if (set.Contains(n))
            {
                return -1;
            }
            else
            {
                set.Add(n);
            }
        }
        return -1;
    }
}
// @lc code=end

