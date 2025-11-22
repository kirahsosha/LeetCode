#
# @lc app=leetcode.cn id=3190 lang=python3
#
# [3190] 使所有元素都可以被 3 整除的最少操作数
#

# @lc code=start
class Solution:
    def minimumOperations(self, nums: List[int]) -> int:
        res = 0
        for n in nums:
            if n % 3 != 0:
                res += 1
        return res
        
# @lc code=end

