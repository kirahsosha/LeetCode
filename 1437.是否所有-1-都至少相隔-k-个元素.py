#
# @lc app=leetcode.cn id=1437 lang=python3
#
# [1437] 是否所有 1 都至少相隔 k 个元素
#

# @lc code=start
class Solution:
    def kLengthApart(self, nums: List[int], k: int) -> bool:
        index = -1
        for i in range(len(nums)):
            if nums[i] == 1 and index == -1:
                index = 0
            elif nums[i] == 1 and index < k:
                return False
            elif nums[i] == 1:
                index = 0
            elif index != -1:
                index += 1
        return True     
# @lc code=end

