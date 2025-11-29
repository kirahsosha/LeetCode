#
# @lc app=leetcode.cn id=3512 lang=python3
#
# [3512] 使数组和能被 K 整除的最少操作次数
#

# @lc code=start
from typing import List


class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        res = 0
        for n in nums:
            res = (res + n) % k
        return res
        
# @lc code=end

