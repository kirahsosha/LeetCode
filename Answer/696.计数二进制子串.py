#
# @lc app=leetcode.cn id=696 lang=python3
#
# [696] 计数二进制子串
#

# @lc code=start
class Solution:
    def countBinarySubstrings(self, s: str) -> int:
        a = '0'
        count = 0
        old = 0
        res = 0
        for c in s:
            if c == a:
                count += 1
            else:
                res += min(old, count)
                old = count
                a = c
                count = 1
        res += min(old, count)
        return res
        
# @lc code=end

