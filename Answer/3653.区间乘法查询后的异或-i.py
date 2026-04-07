#
# @lc app=leetcode.cn id=3653 lang=python3
#
# [3653] 区间乘法查询后的异或 I
#

# @lc code=start
from math import isqrt
from typing import Dict, List


class Solution:
    def xorAfterQueries(self, nums: List[int], queries: List[List[int]]) -> int:
        mod = 10**9 + 7
        n = len(nums)
        limit = min(n, isqrt(len(queries)))
        diff: List[List[int] | None] = [None] * (limit + 1)
        small_ks: List[int] = []
        used = [False] * (limit + 1)
        inverse_cache: Dict[int, int] = {}

        def mul_mod(a: int, b: int) -> int:
            return a * b % mod

        def mod_inverse(value: int) -> int:
            if value not in inverse_cache:
                inverse_cache[value] = pow(value, mod - 2, mod)
            return inverse_cache[value]

        for l, r, k, v in queries:
            if k <= limit:
                if not used[k]:
                    used[k] = True
                    small_ks.append(k)
                    diff[k] = [1] * n

                current = diff[k]
                assert current is not None
                current[l] = mul_mod(current[l], v)
                end = l + (r - l) // k * k + k
                if end < n:
                    current[end] = mul_mod(current[end], mod_inverse(v))
                continue

            for index in range(l, r + 1, k):
                nums[index] = mul_mod(nums[index], v)

        for k in small_ks:
            current = diff[k]
            assert current is not None
            for index in range(n):
                if index >= k:
                    current[index] = mul_mod(current[index], current[index - k])
                nums[index] = mul_mod(nums[index], current[index])

        result = 0
        for num in nums:
            result ^= num
        return result
# @lc code=end

