#
# @lc app=leetcode.cn id=2069 lang=python3
#
# [2069] 模拟行走机器人 II
#

# @lc code=start
from typing import List, Tuple


class Robot:

    def __init__(self, width: int, height: int):
        self.width = width
        self.height = height
        self.perimeter = (width + height - 2) * 2
        self.step_count = 0

    def step(self, num: int) -> None:
        self.step_count = (self.step_count + num - 1) % self.perimeter + 1

    def getPos(self) -> List[int]:
        x, y, _ = self._get_state()
        return [x, y]

    def getDir(self) -> str:
        _, _, direction = self._get_state()
        return direction

    def _get_state(self) -> Tuple[int, int, str]:
        step = self.step_count
        if step < self.width:
            return step, 0, "East"
        if step < self.width + self.height - 1:
            return self.width - 1, step - self.width + 1, "North"
        if step < self.width * 2 + self.height - 2:
            return self.width * 2 + self.height - step - 3, self.height - 1, "West"
        return 0, (self.width + self.height) * 2 - step - 4, "South"


# Your Robot object will be instantiated and called as such:
# obj = Robot(width, height)
# obj.step(num)
# param_2 = obj.getPos()
# param_3 = obj.getDir()
# @lc code=end

