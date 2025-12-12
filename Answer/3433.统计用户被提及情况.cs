/*
 * @lc app=leetcode.cn id=3433 lang=csharp
 *
 * [3433] 统计用户被提及情况
 */

// @lc code=start
public class Solution
{
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        //Value: Event, Ids; Priority: timestamp
        var pq = new PriorityQueue<Tuple<int, string>, int>();
        var all = 0;
        foreach (var ev in events)
        {
            var e = ev[0] == "MESSAGE" ? 0 : 1;
            var t = int.Parse(ev[1]) * 3;
            var ids = ev[2].Replace("id", "");
            if (ids == "ALL")
            {
                all++;
                continue;
            }
            pq.Enqueue(new Tuple<int, string>(e, ids), t - e);
            if (e == 1)
            {
                //Add online event
                pq.Enqueue(new Tuple<int, string>(2, ids), t + 178);
            }
        }
        var status = new int[numberOfUsers];
        var res = new int[numberOfUsers];
        if (all > 0)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                res[i] = all;
            }
        }
        while (pq.TryDequeue(out var ev, out _))
        {
            var e = ev.Item1;
            if (e == 0)
            {
                //MESSAGE
                if (ev.Item2 == "HERE")
                {
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        if (status[i] == 0)
                        {
                            res[i]++;
                        }
                    }
                }
                else
                {
                    var ids = ev.Item2.Split(' ').Select(int.Parse);
                    foreach (var id in ids)
                    {
                        res[id]++;
                    }
                }
            }
            else if (e == 1)
            {
                //OFFLINE
                var id = int.Parse(ev.Item2);
                status[id] = -1;
            }
            else
            {
                //ONLINE
                var id = int.Parse(ev.Item2);
                status[id] = 0;
            }
        }
        return res;
    }
}
// @lc code=end

