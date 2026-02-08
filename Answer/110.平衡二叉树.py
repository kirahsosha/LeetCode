#
# @lc app=leetcode.cn id=110 lang=python3
#
# [110] 平衡二叉树
#

# @lc code=start
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        def getDepth(self, node: Optional[TreeNode]) -> int:
            depth = 0
            if node is None:
                depth = 0
                return depth
            depth = 1
            left = getDepth(self, node.left)
            right = getDepth(self, node.right)
            if left >= 0 and right >= 0:
                depth = max(left, right) + 1
                return depth if abs(left - right) <= 1 else -1
            return -1

        return getDepth(self, root) >= 0
        
# @lc code=end

