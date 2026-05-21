#
# @lc app=leetcode.cn id=2657 lang=python3
#
# [2657] 找到两个数组的前缀公共数组
#

# @lc code=start
from typing import List


class Solution:
    def findThePrefixCommonArray(self, A: List[int], B: List[int]) -> List[int]:
        n = len(A)
        ans = [0] * n
        count = [0] * (n + 1)
        common = 0
        for i in range(n):
            count[A[i]] += 1
            if count[A[i]] == 2:
                common += 1

            count[B[i]] += 1
            if count[B[i]] == 2:
                common += 1

            ans[i] = common

        return ans

# @lc code=end
