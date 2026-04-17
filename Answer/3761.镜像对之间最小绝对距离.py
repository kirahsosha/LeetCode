#
# @lc app=leetcode.cn id=3761 lang=python3
#
# [3761] 镜像对之间最小绝对距离
#

# @lc code=start
from typing import List


class Solution:
    def minMirrorPairDistance(self, nums: List[int]) -> int:
        n = len(nums)
        dic: dict[int, int] = {}
        res = n

        for j, num in enumerate(nums):
            if num in dic:
                res = min(res, j - dic[num])
            rev = 0
            x = num
            while x > 0:
                rev = rev * 10 + x % 10
                x //= 10
            dic[rev] = j

        return -1 if res == n else res
# @lc code=end
