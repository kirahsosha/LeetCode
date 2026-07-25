#
# @lc app=leetcode.cn id=3536 lang=python3
#
# [3536] 两个数字的最大乘积
#

# @lc code=start
class Solution:
    def maxProduct(self, n: int) -> int:
        digit = 0
        ans = 0
        while n > 0:
            d = n % 10
            ans = max(ans, d * digit)
            digit = max(digit, d)
            n //= 10
        return ans
# @lc code=end
