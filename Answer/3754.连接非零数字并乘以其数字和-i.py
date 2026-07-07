#
# @lc app=leetcode.cn id=3754 lang=python3
#
# [3754] 连接非零数字并乘以其数字和 I
#

# @lc code=start
class Solution:
    def sumAndMultiply(self, n: int) -> int:
        x = 0
        pow = 1
        s = 0
        while n > 0:
            d = n % 10
            if d:
                x += d * pow
                pow *= 10
                s += d
            n //= 10
        return x * s
# @lc code=end
