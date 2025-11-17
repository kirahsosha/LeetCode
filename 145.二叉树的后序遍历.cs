/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
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
    IList<int> list = new List<int>{};

    public void orderTree(TreeNode node)
    {
        if(node.left != null) orderTree(node.left);
        if(node.right != null) orderTree(node.right);
        list.Add(node.val);
    }

    public IList<int> PostorderTraversal(TreeNode root) {
        if(root == null) return list;
        orderTree(root);
        return list;
    }
}
// @lc code=end

