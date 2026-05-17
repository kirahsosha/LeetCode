#
# @lc app=leetcode.cn id=1306 lang=python3
#
# [1306] 跳跃游戏 III
#

# @lc code=start
from typing import List


class Solution:
    def canReach(self, arr: List[int], start: int) -> bool:
        visited = [False] * len(arr)
        stack = [start]
        visited[start] = True
        while stack:
            index = stack.pop()
            if arr[index] == 0:
                return True

            next_index = index + arr[index]
            if next_index < len(arr) and not visited[next_index]:
                visited[next_index] = True
                stack.append(next_index)

            prev_index = index - arr[index]
            if prev_index >= 0 and not visited[prev_index]:
                visited[prev_index] = True
                stack.append(prev_index)

        return False
        
# @lc code=end