#
# @lc app=leetcode.cn id=3075 lang=python3
#
# [3075] 幸福值最大化的选择方案
#

# @lc code=start
from typing import List

class Solution:
    def maximumHappinessSum(self, happiness: List[int], k: int) -> int:
        happiness.sort()
        happiness.reverse()
        res = 0
        for i in range(k):
            res += max(0, happiness[i] - i);
        return res
        
# @lc code=end

