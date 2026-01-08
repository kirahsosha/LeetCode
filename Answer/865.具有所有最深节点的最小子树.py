#
# @lc app=leetcode.cn id=865 lang=python3
#
# [865] 具有所有最深节点的最小子树
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
    def subtreeWithAllDeepest(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        node = self.dfs(root, 0)
        return node[0]

    def dfs(self, node: Optional[TreeNode], depth: int) -> [Optional[TreeNode], int]:
        if node is None:
            return [node, depth]
        left = self.dfs(node.left, depth + 1)
        right = self.dfs(node.right, depth + 1)
        if left[0] is not None and right[0] is not None:
            if left[1] > right[1]:
                return left
            elif left[1] < right[1]:
                return right
            else:
                return [node, left[1]]
        elif left[0] is not None:
            return left
        elif right[0] is not None:
            return right
        else:
            return [node, depth]

# @lc code=end

