#
# @lc app=leetcode.cn id=3783 lang=python3
#
# [3783] 整数的镜像距离
#

# @lc code=start
class Solution:
    def mirrorDistance(self, n: int) -> int:
        return abs(n - int(str(n)[::-1]))
# @lc code=end
