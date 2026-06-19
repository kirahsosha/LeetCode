#
# @lc app=leetcode.cn id=1732 lang=python3
#
# [1732] 找到最高海拔
#

# @lc code=start
class Solution:
    def largestAltitude(self, gain: List[int]) -> int:
        max_alt = cur = 0
        for g in gain:
            cur += g
            if cur > max_alt:
                max_alt = cur
        return max_alt
# @lc code=end
