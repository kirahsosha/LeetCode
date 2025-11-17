/*
 * @lc app=leetcode.cn id=226 lang=csharp
 *
 * [226] 翻转二叉树
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
    public TreeNode InvertTree(TreeNode root) {
        if(root == null) return root;
        if(root.left == null && root.right == null) return root;
        Invert(root);
        return root;
    }

    public void Invert(TreeNode root)
    {
        if(root.left == null && root.right == null) return;
        else if(root.left == null)
        {
            root.left = root.right;
            root.right = null;
            Invert(root.left);
        }
        else if(root.right == null)
        {
            root.right = root.left;
            root.left = null;
            Invert(root.right);
        }
        else
        {
            TreeNode t = root.left;
            root.left = root.right;
            root.right = t;
            Invert(root.left);
            Invert(root.right);
        }
    }
}
// @lc code=end

