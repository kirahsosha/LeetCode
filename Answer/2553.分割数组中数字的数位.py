#
# @lc app=leetcode.cn id=2553 lang=python3
#
# [2553] 分割数组中数字的数位
#

# @lc code=start
from typing import List


class Solution:
    def separateDigits(self, nums: List[int]) -> List[int]:
        # Python 中 str() 和列表推导式由 C 实现，比手动数学循环更快
        return [int(c) for num in nums for c in str(num)]
# @lc code=end
