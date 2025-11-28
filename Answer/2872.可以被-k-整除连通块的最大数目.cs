/*
 * @lc app=leetcode.cn id=2872 lang=csharp
 *
 * [2872] 可以被 K 整除连通块的最大数目
 */

// @lc code=start
public class Solution
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        var nodes = new List<int>[n];
        for (int i = 0; i < n; ++i)
        {
            nodes[i] = new List<int>();
        }
        foreach (var edge in edges)
        {
            var l = edge[0];
            var r = edge[1];
            nodes[l].Add(r);
            nodes[r].Add(l);
        }
        var res = 0;
        MaxKDivisibleComponents(-1, 0, nodes, values, k, ref res);
        return res;
    }

    private long MaxKDivisibleComponents(int parent, int child, List<int>[] nodes, int[] values, int k, ref int res)
    {
        long sum = values[child];
        foreach (int neighbor in nodes[child])
        {
            if (neighbor != parent)
            {
                sum += MaxKDivisibleComponents(child, neighbor, nodes, values, k, ref res);
            }
        }
        if (sum % k == 0)
        {
            res++;
            return 0;
        }
        return sum;
    }
}
// @lc code=end

