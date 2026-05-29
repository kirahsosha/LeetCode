#
# @lc app=leetcode.cn id=3300 lang=python3
#
# [3300] 替换为数位和以后的最小元素
#

# @lc code=start
from typing import List


class Solution:
    def minElement(self, nums: List[int]) -> int:
        ans = float("inf")
        for num in nums:
            total = 0
            x = num
            while x > 0:
                total += x % 10
                x //= 10

            if total < ans:
                ans = total

        return int(ans)

# @lc code=end
