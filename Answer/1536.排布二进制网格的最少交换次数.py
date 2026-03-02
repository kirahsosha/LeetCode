#
# @lc app=leetcode.cn id=1536 lang=python3
#
# [1536] 排布二进制网格的最少交换次数
#

# @lc code=start
from typing import List


class Solution:
    def minSwaps(self, grid: List[List[int]]) -> int:
        n = len(grid)
        aim = [0] * n
        for i in range(0, n):
            count = n - 1
            for j in range(n - 1, -1, -1):
                count = j
                if grid[i][j] == 1:
                    break
            aim[i] = count
        ans = 0
        for i in range(0, n):
            j = i
            while j < n and aim[j] > i:
                j += 1
            if j == n:
                return -1
            ans += j - i
            for k in range(j, i - 1, -1):
                aim[k] = aim[k - 1]
        return ans

# @lc code=end

