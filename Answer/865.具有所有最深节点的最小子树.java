/*
 * @lc app=leetcode.cn id=865 lang=java
 *
 * [865] 具有所有最深节点的最小子树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {

    public TreeNode subtreeWithAllDeepest(TreeNode root) {
        var node = Dfs(root, 0);
        return node.getKey();

    }

    private Pair<TreeNode, Integer> Dfs(TreeNode node, int depth) {
        if (node == null) {
            return new Pair<TreeNode, Integer>(node, depth);
        }
        var left = Dfs(node.left, depth + 1);
        var right = Dfs(node.right, depth + 1);
        if (left.getKey() != null && right.getKey() != null) {
            if (left.getValue() > right.getValue()) {
                return left;
            } else if (left.getValue() < right.getValue()) {
                return right;
            } else {
                return new Pair<>(node, left.getValue());
            }
        } else if (left.getKey() != null) {
            return left;
        } else if (right.getKey() != null) {
            return right;
        } else {
            return new Pair<>(node, depth);
        }
    }
}
// @lc code=end

