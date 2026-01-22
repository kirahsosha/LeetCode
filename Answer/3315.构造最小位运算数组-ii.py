#
# @lc app=leetcode.cn id=3315 lang=python3
#
# [3315] 构造最小位运算数组 II
#

# @lc code=start
from typing import List


class Solution:
    def minBitwiseArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        ans = []
        for i in range(0, n):
            value = nums[i]
            if value == 2:
                ans.append(-1)
            else:
                t = ~value
                low = t & -t
                ans.append(value ^ (low >> 1))
        return ans
        
# @lc code=end

