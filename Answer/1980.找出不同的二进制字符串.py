#
# @lc app=leetcode.cn id=1980 lang=python3
#
# [1980] 找出不同的二进制字符串
#

# @lc code=start
from typing import List


class Solution:
    def findDifferentBinaryString(self, nums: List[str]) -> str:
        n = len(nums)
        res = [''] * n
        for i in range(0, n):
            res[i] = '1' if nums[i][i] == '0' else '0'
        return ''.join(res)
        
# @lc code=end

