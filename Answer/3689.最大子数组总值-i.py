#
# @lc app=leetcode.cn id=3689 lang=python3
#
# [3689] 最大子数组总值 I
#

# @lc code=start
from typing import List


class Solution:
    def maxTotalValue(self, nums: List[int], k: int) -> int:
        return (max(nums) - min(nums)) * k
# @lc code=end
