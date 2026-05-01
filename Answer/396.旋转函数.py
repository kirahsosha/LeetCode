#
# @lc app=leetcode.cn id=396 lang=python3
#
# [396] 旋转函数
#

# @lc code=start
from typing import List


class Solution:
    def maxRotateFunction(self, nums: List[int]) -> int:
        n = len(nums)

        total, f = 0, 0
        for i, v in enumerate(nums):
            total += v
            f += i * v

        max_f = f
        for i in range(n - 1, 0, -1):
            f += total - n * nums[i]
            if f > max_f:
                max_f = f
        return max_f
# @lc code=end
