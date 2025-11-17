/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
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
public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> list = new List<int> { };
        if (root == null) return list;
        list.AddRange(InorderTraversal(root.left));
        list.Add(root.val);
        list.AddRange(InorderTraversal(root.right));
        return list;
    }
}
// @lc code=end

