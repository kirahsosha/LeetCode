#
# @lc app=leetcode.cn id=3655 lang=python3
#
# [3655] 区间乘法查询后的异或 II
#

# @lc code=start
from collections import defaultdict
from functools import reduce
from math import isqrt
from operator import xor
from typing import List

class Solution:
    def xorAfterQueries(self, nums: List[int], queries: List[List[int]]) -> int:
        MOD = 1_000_000_007
        prod = defaultdict(lambda: 1)
        for l, r, k, v in queries:
            t = (l, r, k)
            prod[t] = prod[t] * v % MOD

        n = len(nums)
        B = isqrt(len(prod))
        groups = [[] for _ in range(B)]

        for (l, r, k), v in prod.items():
            if k < B:
                groups[k].append((l, r, v))
            else:
                for i in range(l, r + 1, k):
                    nums[i] = nums[i] * v % MOD

        for k, g in enumerate(groups):
            if not g:
                continue

            buckets = [[] for _ in range(k)]
            for t in g:
                buckets[t[0] % k].append(t)

            for start, bucket in enumerate(buckets):
                if not bucket:
                    continue
                if len(bucket) == 1:
                    # 只有一个询问，直接暴力
                    l, r, v = bucket[0]
                    for i in range(l, r + 1, k):
                        nums[i] = nums[i] * v % MOD
                    continue

                m = (n - start - 1) // k + 1
                diff = [1] * (m + 1)
                for l, r, v in bucket:
                    diff[l // k] = diff[l // k] * v % MOD
                    r = (r - start) // k + 1
                    diff[r] = diff[r] * pow(v, -1, MOD) % MOD

                mul_d = 1
                for i in range(m):
                    mul_d = mul_d * diff[i] % MOD
                    j = start + i * k
                    nums[j] = nums[j] * mul_d % MOD

        return reduce(xor, nums)
        
# @lc code=end

