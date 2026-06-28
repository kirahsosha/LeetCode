#
# @lc app=leetcode.cn id=1846 lang=python3
#
# [1846] 减小和重新排列数组后的最大元素
#

# @lc code=start
class Solution:
    def maximumElementAfterDecrementingAndRearranging(self, arr: List[int]) -> int:
        arr.sort()
        ans = 0
        for x in arr:
            if x > ans:
                ans += 1
        return ans
# @lc code=end
