from typing import List
from collections import defaultdict

#
# @lc app=leetcode.cn id=2615 lang=python3
#
# [2615] 等值距离和
#

# @lc code=start
class Solution:
    def distance(self, nums: List[int]) -> List[int]:
        n = len(nums)
        ans = [0] * n

        # 从左向右：计算每个位置左侧同值元素的距离和
        cnt = defaultdict(int)
        total = defaultdict(int)
        for i, num in enumerate(nums):
            c = cnt[num]
            s = total[num]
            ans[i] = i * c - s
            cnt[num] = c + 1
            total[num] = s + i

        # 从右向左：计算每个位置右侧同值元素的距离和并累加
        cnt = defaultdict(int)
        total = defaultdict(int)
        for i in range(n - 1, -1, -1):
            num = nums[i]
            c = cnt[num]
            s = total[num]
            ans[i] += s - i * c
            cnt[num] = c + 1
            total[num] = s + i

        return ans
# @lc code=end
