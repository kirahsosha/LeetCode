/*
 * @lc app=leetcode.cn id=1722 lang=csharp
 *
 * [1722] 执行交换操作后的最小汉明距离
 */

// @lc code=start
public class Solution
{
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        int[] parent = new int[n];
        int[] sz = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            sz[i] = 1;
        }

        Func<int, int> find = null;
        find = x =>
        {
            int root = x;
            while (parent[root] != root) root = parent[root];
            while (parent[x] != x)
            {
                int next = parent[x];
                parent[x] = root;
                x = next;
            }
            return root;
        };

        foreach (int[] swap in allowedSwaps)
        {
            int pa = find(swap[0]);
            int pb = find(swap[1]);
            if (pa != pb)
            {
                if (sz[pa] < sz[pb])
                {
                    int tmp = pa; pa = pb; pb = tmp;
                }
                parent[pb] = pa;
                sz[pa] += sz[pb];
            }
        }

        int[] roots = new int[n];
        for (int i = 0; i < n; i++)
        {
            roots[i] = find(i);
        }

        var groups = new Dictionary<int, Dictionary<int, int>>();
        for (int i = 0; i < n; i++)
        {
            int r = roots[i];
            if (!groups.ContainsKey(r))
            {
                groups[r] = new Dictionary<int, int>();
            }
            var dict = groups[r];
            dict[source[i]] = dict.GetValueOrDefault(source[i], 0) + 1;
        }

        int res = 0;
        for (int i = 0; i < n; i++)
        {
            int r = roots[i];
            var dict = groups[r];
            if (dict.GetValueOrDefault(target[i], 0) > 0)
            {
                dict[target[i]] = dict[target[i]] - 1;
            }
            else
            {
                res++;
            }
        }
        return res;
    }
}
// @lc code=end
