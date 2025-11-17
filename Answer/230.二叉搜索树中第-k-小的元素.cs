/*
 * @lc app=leetcode.cn id=230 lang=csharp
 *
 * [230] 二叉搜索树中第 K 小的元素
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
public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        return InorderBst(root, ref k).val;
    }
    
    private TreeNode InorderBst(TreeNode root, ref int k)
    {
        if (root == null) return null;
        var left = InorderBst(root.left, ref k);
        if (left != null) return left;
        k--;
        if (k == 0) return root;
        return InorderBst(root.right, ref k);
    }
}
// @lc code=end

