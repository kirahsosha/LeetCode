#
# @lc app=leetcode.cn id=2402 lang=python3
#
# [2402] 会议室 III
#

# @lc code=start
import heapq
from typing import List


class Solution:
    def mostBooked(self, n: int, meetings: List[List[int]]) -> int:
        res = [0] * n
        free = list(range(n))
        heapq.heapify(free)
        busy = []

        # 按会议开始时间排序
        meetings.sort(key=lambda x: x)

        cur_time = 0
        min_end_time = 0

        def remove_until_next(time):
            while busy and busy[0][0] <= time:
                _, room_index = heapq.heappop(busy)
                heapq.heappush(free, room_index)

        for start, end in meetings:
            cur_time = max(cur_time, start)

            # 若无空闲会议室，推进到最近的结束时间
            if not free:
                min_end_time = busy[0][0] if busy else 0
                cur_time = max(cur_time, min_end_time)

            # 释放已结束的会议室
            remove_until_next(cur_time)

            # 分配会议室
            room_index = heapq.heappop(free)
            res[room_index] += 1
            duration = end - start
            heapq.heappush(busy, (cur_time + duration, room_index))

        ans = 0
        for i in range(1, n):
            if res[i] > res[ans]:
                ans = i
        return ans
        
# @lc code=end

