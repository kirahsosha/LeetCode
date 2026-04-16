#
# @lc app=leetcode.cn id=3488 lang=python3
#
# [3488] 距离最小相等元素查询
#

# @lc code=start
from typing import List


class Solution:
    def solveQueries(self, nums: List[int], queries: List[int]) -> List[int]:
        n = len(nums)
        left = [0] * n
        right = [0] * n
        first = {}
        last = {}

        for i, x in enumerate(nums):
            if x in last:
                j = last[x]
                left[i] = j
                right[j] = i
            else:
                left[i] = -1
            if x not in first:
                first[x] = i
            last[x] = i

        ans = []
        for i in queries:
            l = left[i]
            if l < 0:
                l = last[nums[i]] - n
            if i - l == n:
                ans.append(-1)
            else:
                r = right[i]
                if r == 0:
                    r = first[nums[i]] + n
                ans.append(min(i - l, r - i))
        return ans
# @lc code=end
