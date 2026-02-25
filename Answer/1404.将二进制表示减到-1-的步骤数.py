#
# @lc app=leetcode.cn id=1404 lang=python3
#
# [1404] 将二进制表示减到 1 的步骤数
#

# @lc code=start
class Solution:
    def numSteps(self, s: str) -> int:
        step = 0
        carry = 0
        for i in range(len(s) - 1, 0, -1):
            step += 1
            if int(s[i]) + carry == 1:
                carry = 1
                step += 1
        return step + carry
            
# @lc code=end

