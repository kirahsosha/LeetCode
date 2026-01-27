/*
 * @lc app=leetcode.cn id=3650 lang=csharp
 *
 * [3650] 边反转的最小路径总成本
 */

// @lc code=start
public class Solution
{
    public int MinCost(int n, int[][] edges)
    {
        //邻接表
        var g = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            g[i] = new List<int[]>();
        }
        foreach (int[] e in edges)
        {
            int x = e[0];
            int y = e[1];
            int wt = e[2];
            g[x].Add([y, wt]);
            g[y].Add([x, wt * 2]);
        }

        var dis = new int[n];
        Array.Fill(dis, int.MaxValue);
        //堆中保存 (起点到节点 x 的最短路长度，节点 x)
        var pq = new PriorityQueue<int[], int>();
        //起点到自己的距离是 0
        dis[0] = 0;
        pq.Enqueue([0, 0], 0);

        while (pq.Count > 0)
        {
            int[] p = pq.Dequeue();
            int disX = p[0];
            int x = p[1];
            if (disX > dis[x])
            {
                //x 之前出堆过
                continue;
            }
            if (x == n - 1)
            {
                //到达终点
                return disX;
            }
            foreach (int[] e in g[x])
            {
                int y = e[0];
                int wt = e[1];
                int newDisY = disX + wt;
                if (newDisY < dis[y])
                {
                    //更新 x 的邻居的最短路
                    //懒更新堆：只插入数据，不更新堆中数据
                    //相同节点可能有多个不同的 newDisY，除了最小的 newDisY，其余值都会触发上面的 continue
                    dis[y] = newDisY;
                    pq.Enqueue([newDisY, y], newDisY);
                }
            }
        }

        return -1;
    }
}
// @lc code=end

