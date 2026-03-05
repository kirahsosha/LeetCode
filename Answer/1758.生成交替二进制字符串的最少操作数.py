#
# @lc app=leetcode.cn id=1758 lang=python3
#
# [1758] 生成交替二进制字符串的最少操作数
#

# @lc code=start
class Solution:
    def minOperations(self, s: str) -> int:
        res = 0
        n = len(s)
        for i, c in enumerate(s):
            if ord(c) - ord('0') != i % 2:
                res += 1
        return min(res, n - res)
        
# @lc code=end

