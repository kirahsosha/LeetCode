#
# @lc app=leetcode.cn id=2770 lang=python3
#
# [2770] 达到末尾下标所需的最大跳跃次数
#

# @lc code=start
class Solution:
    def maximumJumps(self, nums: List[int], target: int) -> int:
        n = len(nums)
        dp = [-1] * n
        dp[0] = 0
        
        for i in range(1, n):
            for j in range(i):
                d = nums[i] - nums[j]
                if d <= target and d >= -target and dp[j] != -1:
                    dp[i] = max(dp[i], dp[j] + 1)
        
        return dp[-1]
# @lc code=end
