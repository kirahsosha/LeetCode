/*
 * @lc app=leetcode.cn id=543 lang=csharp
 *
 * [543] 二叉树的直径
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
    public int DiameterOfBinaryTree(TreeNode root)
    {
        CheckDepth(root, out var maxDepth);
        return maxDepth;
    }

    private int CheckDepth(TreeNode node, out int maxDepth)
    {
        int leftDepth = 0;
        int rightDepth = 0;
        int lmax = 0;
        int rmax = 0;
        if (node.left != null)
        {
            leftDepth = CheckDepth(node.left, out lmax) + 1;
        }

        if (node.right != null)
        {
            rightDepth = CheckDepth(node.right, out rmax) + 1;
        }
        maxDepth = Math.Max(Math.Max(lmax, rmax), leftDepth + rightDepth);
        return Math.Max(leftDepth, rightDepth);
    }
}
// @lc code=end

