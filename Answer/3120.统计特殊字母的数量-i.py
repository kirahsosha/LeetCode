#
# @lc app=leetcode.cn id=3120 lang=python3
#
# [3120] 统计特殊字母的数量 I
#

# @lc code=start
class Solution:
    def numberOfSpecialChars(self, word: str) -> int:
        lower_mask = 0
        upper_mask = 0
        for c in word:
            if 'a' <= c <= 'z':
                lower_mask |= 1 << (ord(c) - ord('a'))
            elif 'A' <= c <= 'Z':
                upper_mask |= 1 << (ord(c) - ord('A'))

        common = lower_mask & upper_mask
        ans = 0
        while common > 0:
            ans += common & 1
            common >>= 1
        return ans
# @lc code=end
