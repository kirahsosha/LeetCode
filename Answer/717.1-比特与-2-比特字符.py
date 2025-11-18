#
# @lc app=leetcode.cn id=717 lang=python3
#
# [717] 1 比特与 2 比特字符
#

# @lc code=start
from typing import List


class Solution:
    def isOneBitCharacter(self, bits: List[int]) -> bool:   
        n = len(bits)
        if n == 1:
            return True
        index = 0
        while index < n:
            if bits[index] == 1:
                index += 2
                if index >= n:
                    return False
            else:
                index += 1
                if index == n:
                    return True
        return True
        
# @lc code=end

