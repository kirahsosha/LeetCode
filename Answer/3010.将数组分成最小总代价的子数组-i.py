#
# @lc app=leetcode.cn id=3010 lang=python3
#
# [3010] 将数组分成最小总代价的子数组 I
#

# @lc code=start
from typing import List


class Solution:
    def minimumCost(self, nums: List[int]) -> int:
        n1 = nums[0]
        nums.pop(0)
        nums.sort()
        return n1 + nums[0] + nums[1]
        
# @lc code=end

