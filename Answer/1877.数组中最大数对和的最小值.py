#
# @lc app=leetcode.cn id=1877 lang=python3
#
# [1877] 数组中最大数对和的最小值
#

# @lc code=start
from typing import List


class Solution:
    def minPairSum(self, nums: List[int]) -> int:
        nums.sort()
        ans = 0
        for i in range(0, len(nums) // 2):
            ans = max(ans, nums[i] + nums[len(nums) - i - 1])
        return ans
        
# @lc code=end

