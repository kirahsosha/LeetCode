#
# @lc app=leetcode.cn id=3433 lang=python3
#
# [3433] 统计用户被提及情况
#

# @lc code=start
from queue import PriorityQueue
from typing import List


class Solution:
    def countMentions(self, numberOfUsers: int, events: List[List[str]]) -> List[int]:
        pq = PriorityQueue()
        all = 0
        
        for ev in events:
            event_type_str = ev[0]
            timestamp_str = ev[1]
            target_str = ev[2]

            e = 0 if event_type_str == "MESSAGE" else 1
            t = int(timestamp_str) * 3
            target_str = target_str.replace("id", "").strip()

            if e == 0:
                if target_str == "ALL":
                    all += 1
                elif target_str == "HERE":
                    pq.put((pq, [t, e, -1]))
                else:
                    id_list = target_str.split()
                    for id_str in id_list:
                        pq.put((pq, [t, e, int(id_str)]))
            else:
                user_id = int(target_str)
                pq.put((pq, [t - 1, e, user_id]))
                pq.put((pq, [t + 178, 2, user_id]))

        status = [0] * numberOfUsers
        res = [all] * numberOfUsers

        while not pq.empty():
            _, item = pq.get()
            event = item[1]
            target_id = item[2]

            if event == 0:
                if target_id == -1:
                    for i in range(numberOfUsers):
                        if status[i] == 0:
                            res[i] += 1
                else:
                    res[target_id] += 1
            elif event == 1:
                status[target_id] = -1
            else:
                status[target_id] = 0

        return res
        
# @lc code=end

