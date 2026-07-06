#
# @lc app=leetcode.cn id=1288 lang=python3
#
# [1288] 删除被覆盖区间
#

# @lc code=start
from typing import List


class Solution:
    def removeCoveredIntervals(self, intervals: List[List[int]]) -> int:
        intervals.sort(key=lambda x: (x[0], -x[1]))
        ans = 0
        end = 0
        for l, r in intervals:
            if r > end:
                ans += 1
                end = r
        return ans
# @lc code=end
