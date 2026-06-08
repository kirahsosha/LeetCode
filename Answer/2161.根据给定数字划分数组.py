#
# @lc app=leetcode.cn id=2161 lang=python3
#
# [2161] 根据给定数字划分数组
#

# @lc code=start
from typing import List


class Solution:
    def pivotArray(self, nums: List[int], pivot: int) -> List[int]:
        less = []
        equal = []
        greater = []
        for num in nums:
            if num < pivot:
                less.append(num)
            elif num > pivot:
                greater.append(num)
            else:
                equal.append(num)
        return less + equal + greater
# @lc code=end
