/*
 * @lc app=leetcode.cn id=572 lang=csharp
 *
 * [572] 另一个树的子树
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
    public bool checkNode(TreeNode t1, TreeNode t2)
    {
        if(t1.val != t2.val) return false;
        if((t1.left == null && t2.left != null) || 
           (t1.left != null && t2.left == null) || 
           (t1.right == null && t2.right != null) || 
           (t1.right != null && t2.right == null))
        {
            return false;
        }
        if(t1.left != null)
        {
            if(!checkNode(t1.left, t2.left)) return false;
        }
        if(t1.right != null)
        {
            if(!checkNode(t1.right, t2.right)) return false;
        }
        return true;
    }

    public bool search(TreeNode n, TreeNode t)
    {
        if(n.val == t.val)
        {
            if(checkNode(n, t)) return true;
        }
        if(n.left != null)
        {
            if(search(n.left, t)) return true;
        }
        if(n.right != null)
        {
            if(search(n.right, t)) return true;
        }
        return false;
    }

    public bool IsSubtree(TreeNode s, TreeNode t) {
        return search(s, t);
    }
}
// @lc code=end

