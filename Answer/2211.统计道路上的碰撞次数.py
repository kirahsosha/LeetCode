#
# @lc app=leetcode.cn id=2211 lang=python3
#
# [2211] 统计道路上的碰撞次数
#

# @lc code=start
class Solution:
    def countCollisions(self, directions: str) -> int:
        # L：state < 0，忽略；state >= 0，更新res += state + 1，state = 0
        # S：state < 0，更新state = 0；state >= 0，更新res += state，state = 0
        # R：state <= 0，更新state = 1；state > 0，更新state += 1
        state = -1
        res = 0
        for c in directions:
            if c == 'L':
                if state >= 0:
                    res += state + 1
                    state = 0
            elif c == 'S':
                if state < 0:
                    state = 0
                else:
                     res += state
                     state = 0
            else:
                if state <= 0:
                    state = 1
                else:
                    state += 1
        return res
        
# @lc code=end

