/*
 * @lc app=leetcode.cn id=110 lang=java
 *
 * [110] 平衡二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode() {}
 * TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
class Solution {
    public boolean isBalanced(TreeNode root) {
        return GetDepth(root) >= 0;
    }

    private int GetDepth(TreeNode node) {
        var depth = 0;
        if (node == null) {
            depth = 0;
            return depth;
        }
        depth = 1;
        var left = GetDepth(node.left);
        var right = GetDepth(node.right);
        if (left >= 0 && right >= 0) {
            depth = Math.max(left, right) + 1;
            return Math.abs(left - right) <= 1 ? depth : -1;
        }
        return -1;
    }
}
// @lc code=end
