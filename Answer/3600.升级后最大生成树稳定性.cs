/*
 * @lc app=leetcode.cn id=3600 lang=csharp
 *
 * [3600] 升级后最大生成树稳定性
 */

// @lc code=start
public class UnionFind
{
    private int[] fa; // 代表元
    public int cc; // 连通块个数

    public UnionFind(int n)
    {
        // 一开始有 n 个集合 {0}, {1}, ..., {n-1}
        // 集合 i 的代表元是自己
        fa = new int[n];
        for (int i = 0; i < n; i++)
        {
            fa[i] = i;
        }
        cc = n;
    }

    // 返回 x 所在集合的代表元
    // 同时做路径压缩，也就是把 x 所在集合中的所有元素的 fa 都改成代表元
    public int Find(int x)
    {
        // 如果 fa[x] == x，则表示 x 是代表元
        if (fa[x] != x)
        {
            fa[x] = Find(fa[x]); // fa 改成代表元
        }
        return fa[x];
    }

    // 把 from 所在集合合并到 to 所在集合中
    // 返回是否合并成功
    public bool Merge(int from, int to)
    {
        int x = Find(from);
        int y = Find(to);
        if (x == y)
        {
            // from 和 to 在同一个集合，不做合并
            return false;
        }
        fa[x] = y; // 合并集合。修改后就可以认为 from 和 to 在同一个集合了
        cc--; // 成功合并，连通块个数减一
        return true;
    }
}

public class Solution
{
    public int MaxStability(int n, int[][] edges, int k)
    {
        var uf = new UnionFind(n);
        var allUf = new UnionFind(n);
        var minS1 = int.MaxValue;
        foreach (var e in edges)
        {
            int x = e[0], y = e[1], s = e[2], must = e[3];
            if (must > 0)
            {
                if (!uf.Merge(x, y))
                {
                    // 必选边成环
                    return -1;
                }
                minS1 = Math.Min(minS1, s);
            }
            allUf.Merge(x, y);
        }

        if (allUf.cc > 1)
        {
            // 图不连通
            return -1;
        }

        var left = uf.cc - 1;
        if (left == 0)
        {
            // 只需选必选边
            return minS1;
        }

        var ans = minS1;
        // Kruskal 求最大生成树
        Array.Sort(edges, (a, b) => b[2] - a[2]);
        foreach (var e in edges)
        {
            int x = e[0], y = e[1], s = e[2], must = e[3];
            if (must == 0 && uf.Merge(x, y))
            {
                ans = Math.Min(ans, left > k ? s : s * 2);
                left--;
                if (left == 0)
                {
                    // 已经得到生成树了
                    break;
                }
            }
        }
        return ans;
    }
}
// @lc code=end

