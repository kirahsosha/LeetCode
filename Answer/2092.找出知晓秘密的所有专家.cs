/*
 * @lc app=leetcode.cn id=2092 lang=csharp
 *
 * [2092] 找出知晓秘密的所有专家
 */

// @lc code=start
public class Solution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        int m = meetings.Length;
        Array.Sort(meetings, (x, y) => x[2].CompareTo(y[2]));
        bool[] secret = new bool[n];
        secret[0] = true;
        secret[firstPerson] = true;
        HashSet<int> vertices = new HashSet<int>();
        Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

        for (int i = 0; i < m;)
        {
            // meetings[i .. j] 为同一时间
            int j = i;
            while (j + 1 < m && meetings[j + 1][2] == meetings[i][2])
            {
                ++j;
            }

            vertices.Clear();
            edges.Clear();
            for (int k = i; k <= j; ++k)
            {
                int x = meetings[k][0], y = meetings[k][1];
                vertices.Add(x);
                vertices.Add(y);
                if (!edges.ContainsKey(x))
                {
                    edges[x] = new List<int>();
                }
                if (!edges.ContainsKey(y))
                {
                    edges[y] = new List<int>();
                }
                edges[x].Add(y);
                edges[y].Add(x);
            }

            Queue<int> q = new Queue<int>();
            foreach (int u in vertices)
            {
                if (secret[u])
                {
                    q.Enqueue(u);
                }
            }
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                if (edges.ContainsKey(u))
                {
                    foreach (int v in edges[u])
                    {
                        if (!secret[v])
                        {
                            secret[v] = true;
                            q.Enqueue(v);
                        }
                    }
                }
            }

            i = j + 1;
        }

        List<int> ans = new List<int>();
        for (int i = 0; i < n; ++i)
        {
            if (secret[i])
            {
                ans.Add(i);
            }
        }
        return ans;
    }
}
// @lc code=end

