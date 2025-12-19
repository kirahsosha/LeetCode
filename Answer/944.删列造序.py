#
# @lc app=leetcode.cn id=944 lang=python3
#
# [944] 删列造序
#

# @lc code=start
from typing import List


class Solution:
    def minDeletionSize(self, strs: List[str]) -> int:
        n = len(strs[0])
        res = 0
        for i in range(n):
            for j in range (1, len(strs)):
                if strs[j][i] < strs[j - 1][i]:
                    res += 1
                    break
        return res
        
# @lc code=end

