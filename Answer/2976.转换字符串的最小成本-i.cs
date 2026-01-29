/*
 * @lc app=leetcode.cn id=2976 lang=csharp
 *
 * [2976] 转换字符串的最小成本 I
 */

// @lc code=start
public class Solution
{
    private const int INF = int.MaxValue / 2;

    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        int[,] G = new int[26, 26];
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                G[i, j] = INF;
            }
            G[i, i] = 0;
        }

        int m = original.Length;
        for (int i = 0; i < m; i++)
        {
            int idx = original[i] - 'a';
            int idy = changed[i] - 'a';
            G[idx, idy] = Math.Min(G[idx, idy], cost[i]);
        }

        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (G[i, k] != INF && G[k, j] != INF)
                    {
                        G[i, j] = Math.Min(G[i, j], G[i, k] + G[k, j]);
                    }
                }
            }
        }

        int n = source.Length;
        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            int idx = source[i] - 'a';
            int idy = target[i] - 'a';
            if (G[idx, idy] == INF)
            {
                return -1;
            }
            ans += G[idx, idy];
        }

        return ans;
    }
}
// @lc code=end

