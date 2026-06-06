#
# @lc app=leetcode.cn id=2574 lang=python3
#
# [2574] 左右元素和的差值
#

# @lc code=start
class Solution:
    def leftRightDifference(self, nums: List[int]) -> List[int]:
        total = sum(nums)
        left_sum = 0
        ans = []
        for v in nums:
            diff = 2 * left_sum + v - total
            ans.append(-diff if diff < 0 else diff)
            left_sum += v
        return ans
# @lc code=end
