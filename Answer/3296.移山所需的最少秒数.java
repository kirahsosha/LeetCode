/*
 * @lc app=leetcode.cn id=3296 lang=java
 *
 * [3296] 移山所需的最少秒数
 */

// @lc code=start
import java.util.PriorityQueue;

class Solution {

    static class Worker {

        int index;
        long nextTime;

        Worker(int index, long nextTime) {
            this.index = index;
            this.nextTime = nextTime;
        }
    }

    public long minNumberOfSeconds(int mountainHeight, int[] workerTimes) {
        int workers = workerTimes.length;
        long res = 0;
        int[] round = new int[workers];
        long[] times = new long[workers];

        PriorityQueue<Worker> pq = new PriorityQueue<>((a, b) -> Long.compare(a.nextTime, b.nextTime));

        // init pq
        for (int i = 0; i < workers; i++) {
            round[i] = 0;
            times[i] = 0;
            pq.offer(new Worker(i, workerTimes[i]));
        }

        while (mountainHeight > 0) {
            Worker w = pq.poll();
            int key = w.index;
            round[key]++;
            times[key] += (long) workerTimes[key] * round[key];
            long nextTime = times[key] + (long) workerTimes[key] * (round[key] + 1);
            pq.offer(new Worker(key, nextTime));
            mountainHeight--;
        }

        for (long t : times) {
            res = Math.max(res, t);
        }

        return res;
    }
}
// @lc code=end

