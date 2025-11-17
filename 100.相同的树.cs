/*
 * @lc app=leetcode.cn id=100 lang=csharp
 *
 * [100] 相同的树
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
    bool searchTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        if (p.val != q.val) return false;
        if (!searchTree(p.left, q.left)) return false;
        if (!searchTree(p.right, q.right)) return false;
        return true;
    }

    public bool IsSameTree(TreeNode p, TreeNode q) {
        return searchTree(p, q);
    }
}
// @lc code=end

