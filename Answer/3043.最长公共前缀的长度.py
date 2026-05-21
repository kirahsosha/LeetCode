#
# @lc app=leetcode.cn id=3043 lang=python3
#
# [3043] 最长公共前缀的长度
#

# @lc code=start
from typing import List


class Solution:
    def longestCommonPrefix(self, arr1: List[int], arr2: List[int]) -> int:
        prefix_set = set()

        for num in arr1:
            n = num
            while n > 0:
                prefix_set.add(n)
                n //= 10

        max_len = 0
        for num in arr2:
            length = 0
            temp = num
            while temp > 0:
                length += 1
                temp //= 10

            n = num
            while n > 0:
                if n in prefix_set:
                    if length > max_len:
                        max_len = length
                    break
                length -= 1
                n //= 10

        return max_len
# @lc code=end
