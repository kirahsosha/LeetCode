#
# @lc app=leetcode.cn id=1358 lang=python3
#
# [1358] 包含所有三种字符的子字符串数目
#

# @lc code=start
class Solution:
    def numberOfSubstrings(self, s: str) -> int:
        last = [-1, -1, -1]
        ans = 0
        a = ord('a')
        for i, ch in enumerate(s):
            last[ord(ch) - a] = i
            ans += min(last) + 1
        return ans
# @lc code=end
