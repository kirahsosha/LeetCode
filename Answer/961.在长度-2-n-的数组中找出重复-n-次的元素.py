#
# @lc app=leetcode.cn id=961 lang=python3
#
# [961] 在长度 2N 的数组中找出重复 N 次的元素
#

# @lc code=start
from typing import List


class Solution:
    def repeatedNTimes(self, nums: List[int]) -> int:
        res = 0
        ans = set()
        for n in nums:
            if n in ans:
                res = n
                break
            ans.add(n)
        return res
        
# @lc code=end

