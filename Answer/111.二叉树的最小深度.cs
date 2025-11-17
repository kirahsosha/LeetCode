/*
 * @lc app=leetcode.cn id=111 lang=csharp
 *
 * [111] 二叉树的最小深度
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
    public int getDeep(TreeNode node, int deep)
    {
        if(node.left != null && node.right != null)
        {
            deep = Math.Min(getDeep(node.left, deep + 1), getDeep(node.right, deep + 1));
        }
        else if(node.left != null)
        {
            deep = getDeep(node.left, deep + 1);
        }
        else if(node.right != null)
        {
            deep = getDeep(node.right, deep + 1);
        }
        return deep;
    }

    public int MinDepth(TreeNode root) {
        if(root == null) return 0;
        return getDeep(root, 1);
    }
}
// @lc code=end

