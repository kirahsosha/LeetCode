/*
 * @lc app=leetcode.cn id=3296 lang=javascript
 *
 * [3296] 移山所需的最少秒数
 */

// @lc code=start
/**
 * @param {number} mountainHeight
 * @param {number[]} workerTimes
 * @return {number}
 */
var minNumberOfSeconds = function (mountainHeight, workerTimes) {
    const n = workerTimes.length;
    const round = new Array(n).fill(0);
    const times = new Array(n).fill(0n);

    // 最小堆：按nextTime排序
    const pq = [];
    for (let i = 0; i < n; i++) {
        pq.push({ index: i, nextTime: BigInt(workerTimes[i]) });
    }

    // 构建最小堆
    const buildHeap = () => {
        for (let i = Math.floor(n / 2) - 1; i >= 0; i--) {
            siftDown(i);
        }
    };

    const siftDown = (idx) => {
        let smallest = idx;
        const left = 2 * idx + 1;
        const right = 2 * idx + 2;

        if (left < pq.length && pq[left].nextTime < pq[smallest].nextTime) {
            smallest = left;
        }
        if (right < pq.length && pq[right].nextTime < pq[smallest].nextTime) {
            smallest = right;
        }

        if (smallest !== idx) {
            [pq[idx], pq[smallest]] = [pq[smallest], pq[idx]];
            siftDown(smallest);
        }
    };

    const siftUp = (idx) => {
        const parent = Math.floor((idx - 1) / 2);
        if (idx > 0 && pq[idx].nextTime < pq[parent].nextTime) {
            [pq[idx], pq[parent]] = [pq[parent], pq[idx]];
            siftUp(parent);
        }
    };

    buildHeap();

    for (let i = 0; i < mountainHeight; i++) {
        const w = pq[0];
        const key = w.index;
        round[key]++;
        times[key] += BigInt(workerTimes[key]) * BigInt(round[key]);

        const nextTime = times[key] + BigInt(workerTimes[key]) * BigInt(round[key] + 1);
        pq[0] = { index: key, nextTime: nextTime };
        siftDown(0);
    }

    return Math.max(...times.map(t => Number(t)));
};
// @lc code=end

