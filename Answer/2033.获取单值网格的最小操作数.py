#
# @lc app=leetcode.cn id=2033 lang=python3
#
# [2033] 获取单值网格的最小操作数
#

# @lc code=start
from typing import List


class Solution:
    def minOperations(self, grid: List[List[int]], x: int) -> int:
        base = grid[0][0]
        nums = []
        
        for row in grid:
            for num in row:
                if (num - base) % x != 0:
                    return -1
                nums.append(num)
        
        nums.sort()
        median = nums[len(nums) // 2]
        return sum(abs(num - median) // x for num in nums)
# @lc code=end
