#
# @lc app=leetcode.cn id=3718 lang=python3
#
# [3718] 缺失的最小倍数
#

# @lc code=start
from typing import List

class Solution:
    def missingMultiple(self, nums: List[int], k: int) -> int:
        s = set(nums)
        multiple = k
        while multiple in s:
            multiple += k
        return multiple
# @lc code=end
