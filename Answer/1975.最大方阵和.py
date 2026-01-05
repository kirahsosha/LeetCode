#
# @lc app=leetcode.cn id=1975 lang=python3
#
# [1975] 最大方阵和
#

# @lc code=start
from typing import List


class Solution:
    def maxMatrixSum(self, matrix: List[List[int]]) -> int:
        n = len(matrix)
        sumPos = 0
        sumNeg = 0
        maxNeg = -100001
        minPos = 100001
        countPos = 0
        countNeg = 0
        for i in range(n):
            for j in range(n):
                k = matrix[i][j]
                if k >= 0:
                    countPos += 1
                    sumPos += k
                    minPos = min(minPos, k)
                else:
                    countNeg += 1
                    sumNeg -= k
                    maxNeg = max(maxNeg, k)
        if countNeg % 2 == 0:
            return sumPos + sumNeg
        elif countPos == 0:
            return sumPos + sumNeg + 2 * maxNeg
        else:
            return max(sumPos + sumNeg + 2 * maxNeg, sumPos + sumNeg - 2 * minPos)
        
# @lc code=end

