#
# @lc app=leetcode.cn id=3016 lang=python3
#
# [3016] 输入单词需要的最少按键次数 II
#

# @lc code=start
class Solution:
    def minimumPushes(self, word: str) -> int:
        # 26 个字母各出现次数，用 str.count 在 C 层完成统计
        vals = sorted([word.count(chr(ord('a') + i)) for i in range(26)], reverse=True)
        return sum((i // 8 + 1) * c for i, c in enumerate(vals) if c)
# @lc code=end
