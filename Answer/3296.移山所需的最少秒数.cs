/*
 * @lc app=leetcode.cn id=3296 lang=csharp
 *
 * [3296] 移山所需的最少秒数
 */

// @lc code=start
public class Solution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        var worker = workerTimes.Length;
        long res = 0;
        var round = new int[worker];
        var times = new long[worker];
        var pq = new PriorityQueue<int, long>();

        // init pq
        for (var i = 0; i < worker; i++)
        {
            round[i] = 0;
            times[i] = 0;
            pq.Enqueue(i, workerTimes[i]);
        }

        while (mountainHeight > 0)
        {
            var key = pq.Dequeue();
            round[key]++;
            times[key] += (long)workerTimes[key] * round[key];
            pq.Enqueue(key, times[key] + workerTimes[key] * (round[key] + 1));
            mountainHeight--;
        }

        foreach (var t in times)
        {
            res = Math.Max(res, t);
        }

        return res;
    }
}
// @lc code=end

