#
# @lc app=leetcode.cn id=1984 lang=python3
#
# [1984] 学生分数的最小差值
#

# @lc code=start
from typing import List


class Solution:
    def minimumDifference(self, nums: List[int], k: int) -> int:
        if k == 1:
            return 0
        nums.sort()
        ans = nums[k - 1] - nums[0]
        for i in range(1, len(nums) - k + 1):
            ans = min(ans, nums[i + k - 1] - nums[i])
        return ans
        
# @lc code=end

