/*
 * @lc app=leetcode.cn id=98 lang=csharp
 *
 * [98] 验证二叉搜索树
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
    public bool checkBrench(TreeNode node, long l, long r)
    {
        bool ans = true;
        if(node.left != null)
        {
            if(node.left.val > l && node.left.val < node.val)
            {
                ans = checkBrench(node.left, l, node.val);
            }
            else
            {
                return false;
            }
        }
        if (!ans) return ans;
        if(node.right != null)
        {
            if(node.right.val > node.val && node.right.val < r)
            {
                ans = checkBrench(node.right, node.val, r);
            }
            else
            {
                return false;
            }
        }
        return ans;
    }

    public bool IsValidBST(TreeNode root) {
        if(root == null) return true;
        return checkBrench(root, long.MinValue, long.MaxValue);
    }
}
// @lc code=end

