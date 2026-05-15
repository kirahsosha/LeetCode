#
# @lc app=leetcode.cn id=2784 lang=python3
#
# [2784] 检查数组是否是好的
#

# @lc code=start
from typing import List


class Solution:
    def isGood(self, nums: List[int]) -> bool:
        n = len(nums) - 1
        if n == 0:
            return False

        cnt = [0] * n
        for num in nums:
            if num > n or num <= 0:
                return False
            if num != n and cnt[num - 1] == 1:
                return False
            if num == n and cnt[num - 1] > 1:
                return False
            cnt[num - 1] += 1
        return True
# @lc code=end
