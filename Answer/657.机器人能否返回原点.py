#
# @lc app=leetcode.cn id=657 lang=python3
#
# [657] 机器人能否返回原点
#

# @lc code=start
class Solution:
    def judgeCircle(self, moves: str) -> bool:
        ver = 0
        hor = 0
        for move in moves:
            if move == 'U':
                ver += 1
            elif move == 'D':
                ver -= 1
            elif move == 'L':
                hor -= 1
            else:
                hor += 1
        return ver == 0 and hor == 0
# @lc code=end

