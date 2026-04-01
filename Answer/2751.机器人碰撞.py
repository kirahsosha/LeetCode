#
# @lc app=leetcode.cn id=2751 lang=python3
#
# [2751] 机器人碰撞
#

# @lc code=start
from typing import List


class Solution:
    def survivedRobotsHealths(self, positions: List[int], healths: List[int], directions: str) -> List[int]:
        n = len(positions)
        order = sorted(range(n), key=positions.__getitem__)

        right_stack: List[int] = []
        for i in order:
            if directions[i] == 'R':
                right_stack.append(i)
                continue

            while right_stack and healths[i] > 0:
                j = right_stack[-1]
                if healths[j] < healths[i]:
                    right_stack.pop()
                    healths[i] -= 1
                    healths[j] = 0
                elif healths[j] > healths[i]:
                    healths[j] -= 1
                    healths[i] = 0
                else:
                    right_stack.pop()
                    healths[j] = 0
                    healths[i] = 0

        return [h for h in healths if h > 0]
# @lc code=end

