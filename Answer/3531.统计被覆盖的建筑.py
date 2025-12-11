#
# @lc app=leetcode.cn id=3531 lang=python3
#
# [3531] 统计被覆盖的建筑
#

# @lc code=start
from typing import List


class Solution:
    def countCoveredBuildings(self, n: int, buildings: List[List[int]]) -> int:
        # Key：横坐标；Value：纵坐标范围
        ver = {}
        # Key：纵坐标；Value：横坐标范围
        hor = {}
        for building in buildings:
            x = building[0]
            y = building[1]
            if ver.get(x, 0) != 0:
                ver[x][0] = min(ver[x][0], y)
                ver[x][1] = max(ver[x][1], y)
            else:
                ver[x] = [y, y]
            if hor.get(y, 0) != 0:
                hor[y][0] = min(hor[y][0], x)
                hor[y][1] = max(hor[y][1], x)
            else:
                hor[y] = [x, x]
        res = 0
        for building in buildings:
            x = building[0]
            y = building[1]
            if ver[x][0] < y < ver[x][1] and hor[y][0] < x < hor[y][1]:
                res = res + 1
        return res
        
# @lc code=end

