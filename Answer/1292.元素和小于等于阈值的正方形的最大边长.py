#
# @lc app=leetcode.cn id=1292 lang=python3
#
# [1292] 元素和小于等于阈值的正方形的最大边长
#

# @lc code=start
from typing import List


class Solution:
    def maxSideLength(self, mat: List[List[int]], threshold: int) -> int:
        m = len(mat)
        n = len(mat[0])
        pre = [[0] * (n + 1) for _ in range(m)]
        for i in range(0, m):
            for j in range(0, n):
                pre[i][j + 1] = pre[i][j] + mat[i][j]
        left = 0
        right = min(m, n)
        while left < right:
            mid = left + (right - left + 1) // 2
            if self.Check(mid, threshold, pre, m, n):
                left = mid
            else:
                right = mid - 1
        return left

    def Check(self, mid: int, threshold: int, pre: List[List[int]], m: int, n: int) -> bool:
        for i in range(0, m - mid + 1):
            for j in range(0, n - mid + 1):
                total = 0
                for k in range(0, mid):
                    total += pre[i + k][j + mid] - pre[i + k][j]
                if total <= threshold:
                    return True
        return False
        
# @lc code=end

