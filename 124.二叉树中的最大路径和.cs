/*
 * @lc app=leetcode.cn id=124 lang=csharp
 *
 * [124] 二叉树中的最大路径和
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
    public int MaxPathSum(TreeNode root)
    {
        return MaxChildValue(root, out _);
    }

    private int MaxChildValue(TreeNode root, out int child)
    {
        int mid = root.val;
        child = root.val;
        int left = -1001;
        int lChild = -1001;
        int right = -1001;
        int rChild = -1001;
        if (root.left != null)
        {
            left = MaxChildValue(root.left, out lChild);
        }
        if (root.right != null)
        {
            right = MaxChildValue(root.right, out rChild);
        }
        var max = Math.Max(mid, Math.Max(left, Math.Max(right, Math.Max(mid + lChild, Math.Max(mid + rChild, mid + lChild + rChild)))));
        child = Math.Max(mid, Math.Max(mid + lChild, mid + rChild));
        return max;
    }
}
// @lc code=end

