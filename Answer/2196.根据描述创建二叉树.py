#
# @lc app=leetcode.cn id=2196 lang=python3
#
# [2196] 根据描述创建二叉树
#

# @lc code=start
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def createBinaryTree(self, descriptions: List[List[int]]) -> Optional[TreeNode]:
        nodes = {}
        has_parent = set()
        vals = []
        for p, c, is_left in descriptions:
            if p not in nodes:
                nodes[p] = TreeNode(p)
                vals.append(p)
            if c not in nodes:
                nodes[c] = TreeNode(c)
                vals.append(c)
            if is_left == 1:
                nodes[p].left = nodes[c]
            else:
                nodes[p].right = nodes[c]
            has_parent.add(c)
        for v in vals:
            if v not in has_parent:
                return nodes[v]
        return None
# @lc code=end
