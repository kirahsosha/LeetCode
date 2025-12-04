#
# @lc app=leetcode.cn id=179 lang=python3
#
# [179] 最大数
#

# @lc code=start
from functools import cmp_to_key
from typing import List

class Solution:
    def largestNumber(self, nums: List[int]) -> str:
        def sort_rule(x, y):
            a, b = x + y, y + x
            if a < b: return 1
            elif a > b: return -1
            else: return 0
        
        strs = [str(num) for num in nums]
        strs.sort(key = cmp_to_key(sort_rule))
        if strs[0] == "0":
            return "0"
        return ''.join(strs)
        
# @lc code=end

