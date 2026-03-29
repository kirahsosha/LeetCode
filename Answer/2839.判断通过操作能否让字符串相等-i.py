#
# @lc app=leetcode.cn id=2839 lang=python3
#
# [2839] 判断通过操作能否让字符串相等 I
#

# @lc code=start
class Solution:
    def canBeEqual(self, s1: str, s2: str) -> bool:
        even_equal = (s1[0] == s2[0] and s1[2] == s2[2]) or (s1[0] == s2[2] and s1[2] == s2[0])
        odd_equal = (s1[1] == s2[1] and s1[3] == s2[3]) or (s1[1] == s2[3] and s1[3] == s2[1])

        return even_equal and odd_equal
# @lc code=end

