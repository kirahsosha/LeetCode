#
# @lc app=leetcode.cn id=66 lang=python3
#
# [66] 加一
#

# @lc code=start
from typing import List


class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        n = len(digits)
        if n == 1 and digits[0] == 0:
            digits[0] = 1
            return digits
        t = 1
        for i in range(n - 1, -1, -1):
            digits[i] += t
            t = 0
            if digits[i] == 10:
                digits[i] = 0
                t = 1
            if t == 0:
                break
        if t == 1:
            a = [1]
            a.extend(digits)
            return a
        else:
            return digits
        
# @lc code=end

