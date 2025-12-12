/*
 * @lc app=leetcode.cn id=3433 lang=javascript
 *
 * [3433] 统计用户被提及情况
 */

// @lc code=start
/**
 * @param {number} numberOfUsers
 * @param {string[][]} events
 * @return {number[]}
 */

var countMentions = function (numberOfUsers, events) {
    const myCompare = (a, b) => {
        return a[0] - b[0]
    };
    //Value: Timestamp, Event, Ids
    const pq = new PriorityQueue(myCompare);
    let all = 0;

    for (const ev of events) {
        const eventTypeStr = ev[0];
        const timestampStr = ev[1];
        let targetStr = ev[2];

        const e = eventTypeStr === "MESSAGE" ? 0 : 1;
        const t = parseInt(timestampStr) * 3;
        targetStr = targetStr.replace(/id/g, "").trim();

        if (e === 0) {
            if (targetStr === "ALL") {
                all++;
            } else if (targetStr === "HERE") {
                pq.enqueue([t, e, -1]);
            } else {
                const idList = targetStr.split(" ");
                for (const id of idList) {
                    pq.enqueue([t, e, parseInt(id)]);
                }
            }
        } else {
            const id = parseInt(targetStr);
            pq.enqueue([t - 1, e, id]);
            pq.enqueue([t + 178, 2, id]);
        }
    }

    const status = new Array(numberOfUsers).fill(0);
    const res = new Array(numberOfUsers).fill(all);

    while (!pq.isEmpty()) {
        const item = pq.dequeue();
        const event = item[1];
        const targetId = item[2];

        if (event === 0) {
            if (targetId === -1) {
                for (let i = 0; i < numberOfUsers; i++) {
                    if (status[i] === 0) {
                        res[i]++;
                    }
                }
            } else {
                res[targetId]++;
            }
        } else if (event === 1) {
            status[targetId] = -1;
        } else {
            status[targetId] = 0;
        }
    }

    return res;
};
// @lc code=end

