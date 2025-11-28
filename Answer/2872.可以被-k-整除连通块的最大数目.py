#
# @lc app=leetcode.cn id=2872 lang=python3
#
# [2872] 可以被 K 整除连通块的最大数目
#

# @lc code=start
from typing import List


class Solution:
    def maxKDivisibleComponents(self, n: int, edges: List[List[int]], values: List[int], k: int) -> int:
        nodes = [[] for _ in range(n)]
        res = 0
        for edge in edges:
            l = edge[0]
            r = edge[1]
            nodes[l].append(r)
            nodes[r].append(l)
        
        def maxKDivisibleComponents(parent, child):
            nonlocal res
            sum=values[child]
            for neighbor in nodes[child]:
                if neighbor != parent:
                    sum += maxKDivisibleComponents(child, neighbor)
            if sum % k == 0:
                res += 1
                return 0
            return sum
        
        maxKDivisibleComponents(-1, 0)
        return res
        
# @lc code=end

