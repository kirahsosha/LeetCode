/*
 * @lc app=leetcode.cn id=3653 lang=csharp
 *
 * [3653] 区间乘法查询后的异或 I
 */

// @lc code=start
public class Solution
{
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        const int mod = 1000000007;
        int n = nums.Length;
        int limit = Math.Min(n, (int)Math.Sqrt(queries.Length));
        int[][] diff = new int[limit + 1][];
        var smallKs = new List<int>(limit);
        var used = new bool[limit + 1];
        var inverseCache = new Dictionary<int, int>();

        foreach (int[] query in queries)
        {
            int l = query[0];
            int r = query[1];
            int k = query[2];
            int v = query[3];
            if (k <= limit)
            {
                if (!used[k])
                {
                    used[k] = true;
                    smallKs.Add(k);
                    diff[k] = new int[n];
                    Array.Fill(diff[k], 1);
                }

                diff[k][l] = MulMod(diff[k][l], v);
                int end = l + (r - l) / k * k + k;
                if (end < n)
                {
                    diff[k][end] = MulMod(diff[k][end], ModInverse(v));
                }
                continue;
            }

            for (int i = l; i <= r; i += k)
            {
                nums[i] = MulMod(nums[i], v);
            }
        }

        foreach (int k in smallKs)
        {
            for (int i = 0; i < n; i++)
            {
                if (i >= k)
                {
                    diff[k][i] = MulMod(diff[k][i], diff[k][i - k]);
                }
                nums[i] = MulMod(nums[i], diff[k][i]);
            }
        }

        int result = 0;
        foreach (int num in nums)
        {
            result ^= num;
        }
        return result;

        int MulMod(int a, int b)
        {
            return (int)((long)a * b % mod);
        }

        int ModInverse(int value)
        {
            if (!inverseCache.TryGetValue(value, out int inverse))
            {
                inverse = ModPow(value, mod - 2);
                inverseCache[value] = inverse;
            }
            return inverse;
        }

        int ModPow(int value, int exponent)
        {
            int result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) != 0)
                {
                    result = MulMod(result, value);
                }
                value = MulMod(value, value);
                exponent >>= 1;
            }
            return result;
        }
    }
}
// @lc code=end

