#
# @lc app=leetcode.cn id=3314 lang=python3
#
# [3314] 构造最小位运算数组 I
#

# @lc code=start
from typing import List


class Solution:
    def minBitwiseArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        ans = []
        for i in range(0, n):
            minNum = nums[i] // 2
            ans.append(-1)
            for j in range(minNum, nums[i]):
                if (j | (j + 1)) == nums[i]:
                    ans[i] = j
                    break
        return ans
        
# @lc code=end

