#
# @lc app=leetcode.cn id=1189 lang=python3
#
# [1189] “气球” 的最大数量
#

# @lc code=start
class Solution:
    def maxNumberOfBalloons(self, text: str) -> int:
        cnt = [0] * 26
        a = ord('a')
        for ch in text:
            cnt[ord(ch) - a] += 1
        return min(
            cnt[ord('b') - a],
            cnt[ord('a') - a],
            cnt[ord('l') - a] // 2,
            cnt[ord('o') - a] // 2,
            cnt[ord('n') - a]
        )
# @lc code=end
