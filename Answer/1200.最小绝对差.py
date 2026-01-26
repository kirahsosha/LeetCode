#
# @lc app=leetcode.cn id=1200 lang=python3
#
# [1200] 最小绝对差
#

# @lc code=start
from typing import List


class Solution:
    def minimumAbsDifference(self, arr: List[int]) -> List[List[int]]:
        ans = []
        minAbs = 1000000
        n = len(arr)
        arr.sort()
        for i in range(0, n - 1):
            currAbs = arr[i + 1] - arr[i]
            if currAbs < minAbs:
                minAbs = currAbs
                ans.clear()
                ans.append([arr[i], arr[i + 1]])
            elif currAbs == minAbs:
                ans.append([arr[i], arr[i + 1]])
        return ans
        
# @lc code=end

