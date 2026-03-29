#
# @lc app=leetcode.cn id=2840 lang=python3
#
# [2840] 判断通过操作能否让字符串相等 II
#

# @lc code=start
class Solution:
    def checkStrings(self, s1: str, s2: str) -> bool:
        cnt1 = [[0] * 26 for _ in range(2)]
        cnt2 = [[0] * 26 for _ in range(2)]
        for i, (c1, c2) in enumerate(zip(s1, s2)):
            cnt1[i % 2][ord(c1) - ord('a')] += 1
            cnt2[i % 2][ord(c2) - ord('a')] += 1

        return cnt1 == cnt2
# @lc code=end

