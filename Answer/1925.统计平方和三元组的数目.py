#
# @lc app=leetcode.cn id=1925 lang=python3
#
# [1925] 统计平方和三元组的数目
#

# @lc code=start
import math


class Solution:
    def countTriples(self, n: int) -> int:
        # a^2 + b^2 = c^2
        # 1 <= a, b, c <= n
        # a, b <= sqrt(n^2 / 2)
        maxa = math.floor(math.sqrt(n * n / 2))
        res = 0
        for a in range(3, maxa + 1):
            maxb = math.floor(math.sqrt(n * n - a * a))
            for b in range(a + 1, maxb + 1):
                sum = math.sqrt(a * a + b * b)
                if sum == math.floor(sum):
                    res += 2
        return res
        
# @lc code=end

