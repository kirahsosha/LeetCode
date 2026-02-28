#
# @lc app=leetcode.cn id=1680 lang=python3
#
# [1680] 连接连续二进制数字
#

# @lc code=start
class Solution:
    def concatenatedBinary(self, n: int) -> int:
        MOD = 1000000007
        res = 0
        for i in range(1, n + 1):
            t = i
            while t > 0:
                t = t >> 1
                res = (res << 1) % MOD
            res = (res + i) % MOD
        return res
        
# @lc code=end

