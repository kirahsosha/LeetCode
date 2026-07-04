/*
 * @lc app=leetcode.cn id=2492 lang=csharp
 *
 * [2492] 两个城市间路径的最小分数
 */

// @lc code=start
public class Solution
{
    public int MinScore(int n, int[][] roads)
    {
        var graph = new Dictionary<int, Dictionary<int, int>>();
        foreach (var road in roads)
        {
            if (!graph.ContainsKey(road[0])) graph[road[0]] = new Dictionary<int, int>();
            if (!graph.ContainsKey(road[1])) graph[road[1]] = new Dictionary<int, int>();
            graph[road[0]][road[1]] = road[2];
            graph[road[1]][road[0]] = road[2];
        }

        int minScore = int.MaxValue;
        var visited = new bool[n + 1];
        var queue = new Queue<int>();
        queue.Enqueue(1);
        visited[1] = true;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var (to, score) in graph[node])
            {
                minScore = Math.Min(minScore, score);
                if (!visited[to])
                {
                    visited[to] = true;
                    queue.Enqueue(to);
                }
            }
        }

        return minScore;
    }
}
// @lc code=end