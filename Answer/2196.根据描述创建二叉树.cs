/*
 * @lc app=leetcode.cn id=2196 lang=csharp
 *
 * [2196] 根据描述创建二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        TreeNode[] nodes = new TreeNode[100001];
        bool[] hasParent = new bool[100001];
        for (int i = 0; i < descriptions.Length; i++) {
            int p = descriptions[i][0];
            int c = descriptions[i][1];
            int isLeft = descriptions[i][2];
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
