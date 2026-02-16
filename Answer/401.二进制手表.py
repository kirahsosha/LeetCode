#
# @lc app=leetcode.cn id=401 lang=python3
#
# [401] 二进制手表
#

# @lc code=start
from typing import List


class Solution:
    def readBinaryWatch(self, turnedOn: int) -> List[str]:
        def combineNumber(self, number, digit, last) -> List[int]:
            if last == 0:
                return [number]
            elif digit == last:
                return combineNumber(self, (number << 1) + 1, digit - 1, last - 1)
            elif digit == 0:
                return combineNumber(self, number << 1, digit, last - 1)
            else:
                nums = []
                for num in combineNumber(self, (number << 1) + 1, digit - 1, last - 1):
                    nums.append(num)
                for num in combineNumber(self, number << 1, digit, last - 1):
                    nums.append(num)
                return nums

        nums = combineNumber(self, 0, turnedOn, 10)
        res = []
        for num in nums:
            minute = num >> 4
            hour = num & 0x0000000f
            if hour < 12 and minute < 60:
                res.append(f"{hour}:{minute:02d}")
        return res
        
# @lc code=end

