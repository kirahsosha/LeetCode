from typing import List

# [198] 打家劫舍
def rob(self, nums: List[int]) -> int:
    # dp[i] = max(dp[i-1], dp[i-2] + num[i])
    # 因为在计算dp[i]的时候只需要使用到dp[i - 1]和dp[i - 2], 所以将数组优化为两个int
    n = len(nums)
    if n == 0:
        return 0
    if n == 1:
        return nums[0]
    if n == 2:
        return max(nums[0], nums[1])
    dp1 = nums[0]
    dp2 = max(nums[0], nums[1])
    for i in range(2, n):
        sum = max(dp1 + nums[i], dp2)
        dp1 = dp2
        dp2 = sum
    return max(dp1, dp2)

# [3577] 统计计算机解锁顺序排列数
def countPermutations(self, complexity: List[int]) -> int:
    MOD = 1000000007
    res = 1
    for i in range(1, len(complexity)):
        if complexity[i] <= complexity[0]:
            return 0
        res = res * i % MOD
    return res