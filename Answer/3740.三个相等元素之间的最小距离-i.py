#
# @lc app=leetcode.cn id=3740 lang=python3
#
# [3740] 三个相等元素之间的最小距离 I
#

# @lc code=start
from typing import List


class Solution:
    def minimumDistance(self, nums: List[int]) -> int:
        positions: dict[int, list[int]] = {}
        best = float("inf")

        for index, num in enumerate(nums):
            state = positions.get(num)
            if state is None:
                positions[num] = [index]
                continue

            if len(state) == 1:
                state.append(index)
                continue

            best = min(best, 2 * (index - state[0]))
            state[0] = state[1]
            state[1] = index

        return -1 if best == float("inf") else int(best)
# @lc code=end

