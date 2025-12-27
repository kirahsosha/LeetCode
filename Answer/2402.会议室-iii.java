
import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.SortedSet;
import java.util.TreeSet;

/*
 * @lc app=leetcode.cn id=2402 lang=java
 *
 * [2402] 会议室 III
 */

// @lc code=start
class Solution {
    public int mostBooked(int n, int[][] meetings) {
        var res = new int[n];
        SortedSet<Integer> free = new TreeSet<>();
        PriorityQueue<long[]> busy = new PriorityQueue<>((a, b) -> Long.compare(a[0], b[0]));
        for (var i = 0; i < n; i++) {
            free.add(i);
        }
        Arrays.sort(meetings, Comparator.comparingInt(a -> a[0]));
        long curTime = 0;
        long minEndTime = 0;
        for (int[] meeting : meetings) {
            var start = meeting[0];
            var end = meeting[1];
            curTime = Math.max(curTime, start);
            if (free.isEmpty()) {
                // 没有空闲会议室，推进到下一个会议室空闲时间
                minEndTime = busy.isEmpty() ? 0 : busy.peek()[0];
                curTime = Math.max(curTime, minEndTime);
            }
            // 释放已结束的会议室
            while (!busy.isEmpty() && busy.peek()[0] <= curTime) {
                free.add((int) busy.poll()[1]);
            }
            // 分配会议室
            var roomIndex = free.first();
            free.remove(roomIndex);
            res[roomIndex]++;
            var duration = end - start;
            busy.offer(new long[] { curTime + duration, roomIndex });
        }
        int ans = 0;
        for (int i = 1; i < n; i++) {
            if (res[i] > res[ans]) {
                ans = i;
            }
        }
        return ans;
    }
}
// @lc code=end
