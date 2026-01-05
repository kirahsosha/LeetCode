#
# @lc app=leetcode.cn id=1161 lang=python3
#
# [1161] 最大层内元素和
#

# @lc code=start
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
from typing import List, Optional


class Solution:
    def maxLevelSum(self, root: Optional[TreeNode]) -> int:
        max = 0
        sum = []
        self.dfs(root, 0, sum)
        for i in range(len(sum)):
            if sum[i] > sum[max]:
                max = i
        return max + 1

    def dfs(self, root: Optional[TreeNode], level: int, sum: List[int]) -> None:
        if root is not None:
            if len(sum) > level:
                sum[level] += root.val
            else:
                sum.append(root.val)
            self.dfs(root.left, level + 1, sum)
            self.dfs(root.right, level + 1, sum)
# @lc code=end

