#
# @lc app=leetcode.cn id=3381 lang=python3
#
# [3381] 长度可被 K 整除的子数组的最大元素和
#

# @lc code=start
class Solution:
    def maxSubarraySum(self, nums: List[int], k: int) -> int:
        n = len(nums)
        pre = [200000000000000 for _ in range(k)]
        sum = 0
        res = -200000000000000
        pre[0] = 0
        for i in range(n):
            sum += nums[i]
            res = max(res, sum - pre[(i + 1) % k])
            pre[(i + 1) % k] = min(pre[(i + 1) % k], sum)
        return res
        
# @lc code=end

