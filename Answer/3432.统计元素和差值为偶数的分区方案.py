#
# @lc app=leetcode.cn id=3432 lang=python3
#
# [3432] 统计元素和差值为偶数的分区方案
#

# @lc code=start
class Solution:
    def countPartitions(self, nums: List[int]) -> int:
        sum = 0
        for i in nums:
            sum += i
        if sum % 2 != 0:
            return 0
        res = 0
        left = 0
        for i in range(0, len(nums) - 1):
            left += nums[i]
            sum -= nums[i]
            if (left - sum) % 2 == 0:
                res += 1
        return res
        
# @lc code=end

