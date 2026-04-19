#
# @lc app=leetcode.cn id=1855 lang=python3
#
# [1855] 下标对中的最大距离
#

# @lc code=start
class Solution:
    def maxDistance(self, nums1: List[int], nums2: List[int]) -> int:
        i = ans = 0
        for j, y in enumerate(nums2):
            while i < len(nums1) and nums1[i] > y:
                i += 1
            if i == len(nums1):
                break
            ans = max(ans, j - i)
        return ans
# @lc code=end
