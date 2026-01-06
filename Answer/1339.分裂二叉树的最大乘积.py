#
# @lc app=leetcode.cn id=1339 lang=python3
#
# [1339] 分裂二叉树的最大乘积
#

# @lc code=start
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import Optional


class Solution:
    def maxProduct(self, root: Optional[TreeNode]) -> int:
        MOD = 1000000007
        sums = set()
        total = self.Dfs(root, sums)
        mi = total
        res = 0
        for item in sums:
            if abs(total - item - item) < mi:
                res = item
                mi = abs(total - item - item)
        return res * (total - res) % MOD

    def Dfs(self, node: Optional[TreeNode], sums: set()) -> int:
        left = 0
        right = 0
        if node.left is not None:
            left = self.Dfs(node.left, sums)
            sums.add(left)
        if node.right is not None:
            right = self.Dfs(node.right,sums)
            sums.add(right)
        return node.val + left + right
        
# @lc code=end

