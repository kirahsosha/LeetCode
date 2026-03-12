#
# @lc app=leetcode.cn id=3296 lang=python3
#
# [3296] 移山所需的最少秒数
#

# @lc code=start
from typing import List
import heapq


class Solution:
    def minNumberOfSeconds(self, mountainHeight: int, workerTimes: List[int]) -> int:
        worker = len(workerTimes)
        round_count = [0] * worker
        times = [0] * worker
        pq = []

        # init pq
        for i in range(0, worker):
            heapq.heappush(pq, (workerTimes[i], i))

        for _ in range(mountainHeight):
            next_time, key = heapq.heappop(pq)
            round_count[key] += 1
            times[key] = next_time
            heapq.heappush(pq, (times[key] + workerTimes[key] * (round_count[key] + 1), key))

        return max(times)
# @lc code=end

