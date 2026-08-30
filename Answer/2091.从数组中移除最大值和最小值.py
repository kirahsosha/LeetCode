#
# @lc app=leetcode.cn id=2091 lang=python3
#
# [2091] 从数组中移除最大值和最小值
#

# @lc code=start
from typing import List


class Solution:
    def minimumDeletions(self, nums: List[int]) -> int:
        min_index = 0
        max_index = 0
        for i in range(1, len(nums)):
            if nums[i] < nums[min_index]:
                min_index = i
            if nums[i] > nums[max_index]:
                max_index = i
        if min_index > max_index:
            min_index, max_index = max_index, min_index
        n = len(nums)
        return min(max_index + 1, n - min_index, min_index + 1 + n - max_index)
# @lc code=end