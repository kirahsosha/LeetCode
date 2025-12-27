/*
 * @lc app=leetcode.cn id=2402 lang=csharp
 *
 * [2402] 会议室 III
 */

// @lc code=start
public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        var res = new int[n];
        var free = new SortedSet<int>();
        var busy = new PriorityQueue<(long endTime, int roomIndex), long>();
        for (var i = 0; i < n; i++)
        {
            free.Add(i);
        }
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        long curTime = 0;
        long minEndTime = 0;
        foreach (var meeting in meetings)
        {
            var start = meeting[0];
            var end = meeting[1];
            curTime = Math.Max(curTime, start);
            if (free.Count == 0)
            {
                //没有空闲会议室，推进到下一个会议室空闲时间
                minEndTime = busy.Count == 0 ? 0 : busy.Peek().endTime;
                curTime = Math.Max(curTime, minEndTime);
            }
            //释放已结束的会议室
            RemoveUntilNext(curTime);
            //分配会议室
            var roomIndex = free.Min;
            free.Remove(roomIndex);
            res[roomIndex]++;
            var duration = end - start;
            busy.Enqueue((curTime + duration, roomIndex), curTime + duration);
        }
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            if (res[i] > res[ans])
            {
                ans = i;
            }
        }
        return ans;

        void RemoveUntilNext(long time)
        {
            while (busy.Count > 0 && busy.Peek().endTime <= time)
            {
                free.Add(busy.Dequeue().roomIndex);
            }
        }
    }
}
// @lc code=end

