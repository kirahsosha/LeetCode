#
# @lc app=leetcode.cn id=3583 lang=python3
#
# [3583] 统计特殊三元组
#

# @lc code=start
from typing import List


class Solution:
    def specialTriplets(self, nums: List[int]) -> int:
        MOD = 1000000007
        # 记录每个值的出现次数
        dic = {}
        # 记录i左边有多少符合条件nums[i]*2的值
        count = {}
        for i in range(len(nums)):
            dic[nums[i]] = dic.get(nums[i], 0) + 1
            if nums[i] != 0 and dic.get(nums[i] * 2, 0) != 0:
                count[i] = dic.get(nums[i] * 2, 0)
        res = 0
        for key in count.keys():
            value = count.get(key)
            if key != 0:
                right = dic.get(nums[key] * 2, 0) - value
                res = (value * right + res) % MOD
        # 处理0
        if dic.get(0, 0) >= 3:
            zero = dic.get(0, 0) * (dic.get(0, 0) - 1) * (dic.get(0, 0) - 2) / 6 % MOD
            res = (res + int(zero)) % MOD
        return res
        
# @lc code=end

