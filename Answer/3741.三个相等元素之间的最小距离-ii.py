#
# @lc app=leetcode.cn id=3741 lang=python3
#
# [3741] 三个相等元素之间的最小距离 II
#

# @lc code=start
from typing import List


class Solution:
    def minimumDistance(self, nums: List[int]) -> int:
        positions: dict[int, list[int]] = {}
        best = -1

        for index, num in enumerate(nums):
            state = positions.get(num)
            if state is None:
                positions[num] = [index]
                continue

            if len(state) == 1:
                state.append(index)
                continue

            if best == -1:
                best = 2 * (index - state[0])
            else:
                best = min(best, 2 * (index - state[0]))
            state[0] = state[1]
            state[1] = index

        return best
        
# @lc code=end

