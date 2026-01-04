#
# @lc app=leetcode.cn id=1390 lang=python3
#
# [1390] 四因数
#

# @lc code=start
import math
from typing import List


class Solution:
    def sumFourDivisors(self, nums: List[int]) -> int:
        res = 0
        for n in nums:
            di = AllDivisors(self, n)
            if len(di) == 4:
                for i in di:
                    res += i
        return res


def AllDivisors(self, n: int) -> List[int]:
    res = set()
    for i in range(1, math.floor(math.sqrt(n)) + 1):
        if n % i == 0:
            res.add(i)
            res.add(n // i)
    return res
        
# @lc code=end

