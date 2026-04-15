#
# @lc app=leetcode.cn id=2515 lang=python3
#
# [2515] 到目标字符串的最短距离
#

# @lc code=start
from typing import List


class Solution:
    def closestTarget(self, words: List[str], target: str, startIndex: int) -> int:
        n = len(words)
        for i in range(n // 2 + 1):
            if words[(startIndex + i) % n] == target or words[(startIndex - i) % n] == target:
                return i
        return -1
# @lc code=end

