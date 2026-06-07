/*
 * @lc app=leetcode.cn id=2196 lang=java
 *
 * [2196] 根据描述创建二叉树
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
    public TreeNode createBinaryTree(int[][] descriptions) {
        TreeNode[] nodes = new TreeNode[100001];
        boolean[] hasParent = new boolean[100001];
        for (int[] d : descriptions) {
            int p = d[0], c = d[1], isLeft = d[2];
            if (nodes[p] == null) {
                nodes[p] = new TreeNode(p);
            }
            if (nodes[c] == null) {
                nodes[c] = new TreeNode(c);
            }
            if (isLeft == 1) {
                nodes[p].left = nodes[c];
            } else {
                nodes[p].right = nodes[c];
            }
            hasParent[c] = true;
        }
        for (int i = 1; i <= 100000; i++) {
            if (nodes[i] != null && !hasParent[i]) {
                return nodes[i];
            }
        }
        return null;
    }
}
// @lc code=end
