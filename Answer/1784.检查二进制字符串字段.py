#
# @lc app=leetcode.cn id=1784 lang=python3
#
# [1784] 检查二进制字符串字段
#

# @lc code=start
class Solution:
    def checkOnesSegment(self, s: str) -> bool:
        res = False
        hasZero = False
        for c in s:
            if c == '1' and not res:
                res = True
            elif c == '0' and res:
                hasZero = True
            elif c == '1' and hasZero:
                return False
        return res
        
# @lc code=end

