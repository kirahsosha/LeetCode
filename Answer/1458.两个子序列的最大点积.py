#
# @lc app=leetcode.cn id=1458 lang=python3
#
# [1458] 两个子序列的最大点积
#

# @lc code=start
from typing import List


class Solution:
    def maxDotProduct(self, nums1: List[int], nums2: List[int]) -> int:
        # i - nums1 index
        # j - nums2 index
        # dp[i][j] = max(dp[i-1][j-1], dp[i-1][j-1] + nums1[i] * nums2[j])
        n1 = len(nums1)
        n2 = len(nums2)
        dp = [[0] * n2 for _ in range(n1)]
        res = -1000000
        for i in range(n1):
            for j in range(n2):
                if i == 0 and j == 0:
                    dp[0][0] = max(-1000000, nums1[i] * nums2[j])
                    res = max(res, dp[i][j])
                elif i == 0:
                    dp[0][j] = max(dp[0][j - 1], nums1[i] * nums2[j])
                    res = max(res, dp[i][j])
                elif j == 0:
                    dp[i][0] = max(dp[i - 1][0], nums1[i] * nums2[j])
                    res = max(res, dp[i][j])
                else:
                    dp[i][j] = max(dp[i][j - 1], dp[i - 1][j], dp[i - 1][j - 1])
                    dp[i][j] = max(dp[i][j], dp[i - 1][j - 1] + nums1[i] * nums2[j], nums1[i] * nums2[j])
                    res = max(res, dp[i][j])
        return res
        
# @lc code=end

