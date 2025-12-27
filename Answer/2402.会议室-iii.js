/*
 * @lc app=leetcode.cn id=2402 lang=javascript
 *
 * [2402] 会议室 III
 */

// @lc code=start
/**
 * @param {number} n
 * @param {number[][]} meetings
 * @return {number}
 */
var mostBooked = function (n, meetings) {
    let res = Array(n).fill(0);
    let free = new MinPriorityQueue({ compare: (a, b) => a - b });
    let busy = new MinPriorityQueue({ compare: (a, b) => a[0] - b[0] });
    for (let i = 0; i < n; i++) {
        free.enqueue(i);
    }
    meetings.sort((a, b) => a[0] - b[0]);
    let curTime = 0;
    let minEndTime = 0;
    meetings.forEach(meeting => {
        let start = meeting[0];
        let end = meeting[1];
        curTime = Math.max(curTime, start);
        if (free.isEmpty()) {
            // 没有空闲会议室，推进到下一个会议室空闲时间
            minEndTime = busy.isEmpty() ? 0 : busy.front()[0];
            curTime = Math.max(curTime, minEndTime);
        }
        // 释放已结束的会议室
        while (!busy.isEmpty() && busy.front()[0] <= curTime) {
            free.enqueue(busy.dequeue()[1]);
        }
        // 分配会议室
        let roomIndex = free.front();
        free.dequeue(roomIndex);
        res[roomIndex]++;
        let duration = end - start;
        busy.enqueue([curTime + duration, roomIndex]);
    });
    let ans = 0;
    for (let i = 1; i < n; i++) {
        if (res[i] > res[ans]) {
            ans = i;
        }
    }
    return ans;

};
// @lc code=end

