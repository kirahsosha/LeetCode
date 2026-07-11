/*
 * @lc app=leetcode.cn id=2685 lang=csharp
 *
 * [2685] 统计完全连通分量的数量
 */

// @lc code=start
public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }
        foreach (var e in edges)
        {
            int u = e[0], v = e[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var visited = new bool[n];
        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                int vCount = 0, eCount = 0;
                Dfs(i, graph, visited, ref vCount, ref eCount);
                if (eCount == vCount * (vCount - 1))
                {
                    ans++;
                }
            }
        }

        return ans;

        void Dfs(int u, List<int>[] graph, bool[] visited, ref int vCount, ref int eCount)
        {
            visited[u] = true;
            vCount++;
            eCount += graph[u].Count;
            foreach (int v in graph[u])
            {
                if (!visited[v])
                {
                    Dfs(v, graph, visited, ref vCount, ref eCount);
                }
            }
        }
    }
}
// @lc code=end

