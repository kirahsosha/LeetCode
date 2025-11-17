/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool searchTree(TreeNode l, TreeNode r)
    {
        if (l == null && r == null) return true;
		if (l == null || r == null) return false;
		if (l.val != r.val) return false;
		if (searchTree(l.left, r.right) == false) return false;
		else if (searchTree(l.right, r.left) == false) return false;
		return true;
    }

    public bool IsSymmetric(TreeNode root) {
        if(root == null) return true;
        if(root.left == null && root.right == null) return true;
        if(root.left == null || root.right == null) return false;
        return searchTree(root.left, root.right);
    }
}
// @lc code=end

