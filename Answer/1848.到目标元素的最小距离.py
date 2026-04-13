#
# @lc app=leetcode.cn id=1848 lang=python3
#
# [1848] 到目标元素的最小距离
#

# @lc code=start
class Solution:
    def getMinDistance(self, nums: List[int], target: int, start: int) -> int:
        # 使用 Pythonic 的方式：遍历所有匹配 target 的下标，计算最小距离
        return min(abs(i - start) for i, num in enumerate(nums) if num == target)
# @lc code=end
