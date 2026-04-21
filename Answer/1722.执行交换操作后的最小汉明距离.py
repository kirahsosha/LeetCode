#
# @lc app=leetcode.cn id=1722 lang=python3
#
# [1722] 执行交换操作后的最小汉明距离
#

# @lc code=start
from typing import List
from collections import defaultdict


class Solution:
    def minimumHammingDistance(self, source: List[int], target: List[int], allowedSwaps: List[List[int]]) -> int:
        n = len(source)
        parent = list(range(n))
        sz = [1] * n

        def find(x: int) -> int:
            root = x
            while parent[root] != root:
                root = parent[root]
            while parent[x] != x:
                parent[x], x = root, parent[x]
            return root

        for a, b in allowedSwaps:
            pa, pb = find(a), find(b)
            if pa != pb:
                if sz[pa] < sz[pb]:
                    pa, pb = pb, pa
                parent[pb] = pa
                sz[pa] += sz[pb]

        roots = [find(i) for i in range(n)]

        groups = defaultdict(lambda: defaultdict(int))
        for i in range(n):
            groups[roots[i]][source[i]] += 1

        res = 0
        for i in range(n):
            cnt = groups[roots[i]]
            if cnt[target[i]] > 0:
                cnt[target[i]] -= 1
            else:
                res += 1
        return res

# @lc code=end
