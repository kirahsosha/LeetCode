#
# @lc app=leetcode.cn id=2126 lang=python3
#
# [2126] 摧毁小行星
#

# @lc code=start
from typing import List


class Solution:
    def asteroidsDestroyed(self, mass: int, asteroids: List[int]) -> bool:
        asteroids.sort()
        current_mass = mass
        for asteroid in asteroids:
            if current_mass < asteroid:
                return False
            current_mass += asteroid
        return True


# @lc code=end
