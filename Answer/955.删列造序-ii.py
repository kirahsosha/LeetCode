#
# @lc app=leetcode.cn id=955 lang=python3
#
# [955] 删列造序 II
#

# @lc code=start
from typing import List


class Solution:
    def minDeletionSize(self, strs: List[str]) -> int:
        n = len(strs)
        m = len(strs[0])
        cuts = [False] * (n - 1)
        ans = 0
        for j in range(m):
            check = True
            for i in range(n - 1):
                if not cuts[i] and strs[i][j] > strs[i + 1][j]:
                    ans += 1
                    check = False
                    break
            if check:
                for i in range(n - 1):
                    if strs[i][j] < strs[i + 1][j]:
                        cuts[i] = True
        return ans
        
# @lc code=end

