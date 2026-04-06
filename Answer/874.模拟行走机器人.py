#
# @lc app=leetcode.cn id=874 lang=python3
#
# [874] 模拟行走机器人
#

# @lc code=start
from typing import List

class Solution:
    def robotSim(self, commands: List[int], obstacles: List[List[int]]) -> int:
        obs = {(x, y) for x, y in obstacles}
        x = y = dir = 0
        ans = 0
        dx = [0, 1, 0, -1]
        dy = [1, 0, -1, 0]
        for cmd in commands:
            if cmd == -2:
                dir = (dir + 3) % 4
            elif cmd == -1:
                dir = (dir + 1) % 4
            else:
                for _ in range(cmd):
                    nx = x + dx[dir]
                    ny = y + dy[dir]
                    if (nx, ny) not in obs:
                        x, y = nx, ny
                        ans = max(ans, x*x + y*y)
        return ans
# @lc code=end

