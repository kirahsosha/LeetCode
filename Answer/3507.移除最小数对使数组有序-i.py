#
# @lc app=leetcode.cn id=3507 lang=python3
#
# [3507] 移除最小数对使数组有序 I
#

# @lc code=start
from typing import List


class Solution:
    def minimumPairRemoval(self, nums: List[int]) -> int:
        times = 0
        while not self.Check(nums):
            index = self.GetMin(nums)
            nums = self.Replace(nums, index)
            times += 1
        return times


    def GetMin(self, nums: List[int]) -> int:
        res = nums[0] + nums[1]
        index = 0
        for i in range(0, len(nums) - 1):
            if nums[i] + nums[i + 1] < res:
                res = nums[i] + nums[i + 1]
                index = i
        return index


    def Replace(self, nums: List[int], index: int) -> List[int]:
        newNums = []
        for i in range(0, index):
            newNums.append(nums[i])
        newNums.append(nums[index] + nums[index + 1])
        for i in range(index + 2, len(nums)):
            newNums.append(nums[i])
        return newNums


    def Check(self, nums: List[int]) -> bool:
        if len(nums) <= 1:
            return True
        for i in range(0, len(nums) - 1):
            if nums[i] > nums[i + 1]:
                return False
        return True
        
# @lc code=end

