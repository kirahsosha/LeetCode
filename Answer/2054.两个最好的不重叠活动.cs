/*
 * @lc app=leetcode.cn id=2054 lang=csharp
 *
 * [2054] 两个最好的不重叠活动
 */

// @lc code=start
public class Solution
{
    public int MaxTwoEvents(int[][] events)
    {
        List<Event> evs = new List<Event>();
        foreach (var eventArr in events)
        {
            evs.Add(new Event(eventArr[0], 0, eventArr[2]));
            evs.Add(new Event(eventArr[1], 1, eventArr[2]));
        }
        evs.Sort();

        int ans = 0, bestFirst = 0;
        foreach (var ev in evs)
        {
            if (ev.Op == 0)
            {
                ans = Math.Max(ans, ev.Val + bestFirst);
            }
            else
            {
                bestFirst = Math.Max(bestFirst, ev.Val);
            }
        }
        return ans;
    }
    class Event : IComparable<Event>
    {
        public int Ts { get; set; }
        public int Op { get; set; }
        public int Val { get; set; }

        public Event(int ts, int op, int val)
        {
            Ts = ts;
            Op = op;
            Val = val;
        }

        public int CompareTo(Event other)
        {
            if (Ts != other.Ts)
            {
                return Ts.CompareTo(other.Ts);
            }
            return Op.CompareTo(other.Op);
        }
    }
}
// @lc code=end

