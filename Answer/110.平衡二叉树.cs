/*
 * @lc app=leetcode.cn id=110 lang=csharp
 *
 * [110] 平衡二叉树
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
    public bool IsBalanced(TreeNode root)
    {
        return GetDepth(root, out _);

        bool GetDepth(TreeNode node, out int depth)
        {
            if (node == null)
            {
                depth = 0;
                return true;
            }
            depth = 1;
            if (GetDepth(node.left, out var left) && GetDepth(node.right, out var right))
            {
                depth = Math.Max(left, right) + 1;
                return Math.Abs(left - right) <= 1;
            }
            return false;
        }
    }
}
// @lc code=end

