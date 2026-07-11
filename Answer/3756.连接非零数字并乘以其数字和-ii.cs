/*
 * @lc app=leetcode.cn id=3756 lang=csharp
 *
 * [3756] 连接非零数字并乘以其数字和 II
 */

// @lc code=start
public class Solution
{
    public const int MOD = 1000000007;

    public int[] SumAndMultiply(string s, int[][] queries)
    {
        int n = s.Length;
        int[] digits = new int[n];
        int[] compIndex = new int[n];
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            int d = s[i] - '0';
            digits[i] = d;
            compIndex[i] = d != 0 ? k++ : -1;
        }

        long[] pHash = new long[k + 1];
        int[] pSum = new int[k + 1];
        long[] pow10 = new long[k + 1];
        pow10[0] = 1;
        int idx = 0;
        for (int i = 0; i < n; i++)
        {
            int d = digits[i];
            if (d != 0)
            {
                idx++;
                pHash[idx] = (pHash[idx - 1] * 10 + d) % MOD;
                pSum[idx] = pSum[idx - 1] + d;
                pow10[idx] = (pow10[idx - 1] * 10) % MOD;
            }
        }

        int[] next = new int[n];
        int last = -1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] != 0) last = i;
            next[i] = last;
        }

        int[] prev = new int[n];
        last = -1;
        for (int i = 0; i < n; i++)
        {
            if (digits[i] != 0) last = i;
            prev[i] = last;
        }

        int q = queries.Length;
        int[] ans = new int[q];
        for (int i = 0; i < q; i++)
        {
            int l = queries[i][0];
            int r = queries[i][1];
            int L = next[l];
            int R = prev[r];
            if (L == -1 || R == -1 || L > R)
            {
                ans[i] = 0;
                continue;
            }

            int li = compIndex[L] + 1;
            int ri = compIndex[R] + 1;
            int len = ri - li + 1;
            long x = pHash[ri] - pHash[li - 1] * pow10[len] % MOD;
            if (x < 0) x += MOD;
            int sum = pSum[ri] - pSum[li - 1];
            ans[i] = (int)(x * sum % MOD);
        }
        return ans;
    }
}
// @lc code=end
