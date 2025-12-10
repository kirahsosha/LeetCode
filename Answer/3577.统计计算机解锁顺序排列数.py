#
# @lc app=leetcode.cn id=3577 lang=python3
#
# [3577] 统计计算机解锁顺序排列数
#

# @lc code=start
from typing import List


class Solution:
    def countPermutations(self, complexity: List[int]) -> int:
        MOD = 1000000007
        res = 1
        for i in range(1,len(complexity)):
            if complexity[i] <= complexity[0]:
                return 0
            res = res * i % MOD
        return res
        
# @lc code=end

