import json
from collections import deque

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

    @staticmethod
    def create_tree_node(s: str):
        nums = json.loads(s)
        nodes = deque()
        for n in nums:
            if n is not None:
                node = TreeNode(n)
                nodes.append(node)
            else:
                nodes.append(None)

        root = nodes.popleft()
        q = deque([root])
        while nodes:
            node = q.popleft()
            node.left = nodes.popleft()
            node.right = nodes.popleft() if nodes else None
            if node.left is not None:
                q.append(node.left)
            if node.right is not None:
                q.append(node.right)
        return root