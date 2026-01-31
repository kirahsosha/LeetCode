#
# @lc app=leetcode.cn id=744 lang=python3
#
# [744] 寻找比目标字母大的最小字母
#

# @lc code=start
from typing import List


class Solution:
    def nextGreatestLetter(self, letters: List[str], target: str) -> str:
        index = 0
        for i in range(0, len(letters)):
            if letters[i] > target:
                index = i
                break
        return letters[index]
        
# @lc code=end

