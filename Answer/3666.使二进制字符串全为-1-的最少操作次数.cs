/*
 * @lc app=leetcode.cn id=3666 lang=csharp
 *
 * [3666] 使二进制字符串全为 1 的最少操作次数
 */

// @lc code=start
public class Solution
{
    public int MinOperations(string s, int k)
    {
        int n = s.Length;
        var c0 = s.Count(c => c == '0');
        var c1 = n - c0;
        if (c0 == 0) return 0;
        if (k == c0) return 1;
        if (k == n) return -1;

        int ans = int.MaxValue;
        // 情况一：操作次数 m 是偶数
        if (c0 % 2 == 0)
        {
            // c0 必须是偶数
            int m = Math.Max((c0 + k - 1) / k, (c0 + n - k - 1) / (n - k)); // 下界
            ans = m + m % 2; // 把 m 往上调整为偶数
        }

        // 情况二：操作次数 m 是奇数
        if (c0 % 2 == k % 2)
        {
            // c0 和 k 的奇偶性必须相同
            int m = Math.Max((c0 + k - 1) / k, (c1 + n - k - 1) / (n - k)); // 下界
            ans = Math.Min(ans, m | 1); // 把 m 往上调整为奇数
        }

        return ans < int.MaxValue ? ans : -1;
    }
}
// @lc code=end

