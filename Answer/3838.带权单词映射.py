#
# @lc app=leetcode.cn id=3838 lang=python3
#
# [3838] 带权单词映射
#

# @lc code=start
from typing import List


class Solution:
    def mapWordWeights(self, words: List[str], weights: List[int]) -> str:
        res = []
        for word in words:
            w = 0
            for ch in word:
                w = (w + weights[ord(ch) - 97]) % 26
            res.append(chr(97 + 25 - w))
        return ''.join(res)
# @lc code=end
