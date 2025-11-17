/*
 * @lc app=leetcode.cn id=112 lang=csharp
 *
 * [112] 路径总和
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
    public bool getSum(TreeNode node, int sum, int ans)
    {
        ans += node.val;
        if(node.left != null && node.right != null)
        {
            return (getSum(node.left, sum, ans) || getSum(node.right, sum, ans));
        }
        else if(node.left != null)
        {
            return getSum(node.left, sum, ans);
        }
        else if(node.right != null)
        {
            return getSum(node.right, sum, ans);
        }
        else
        {
            return sum == ans;
        }
    }

    public bool HasPathSum(TreeNode root, int sum) {
        if(root == null) return false;
        return getSum(root, sum, 0);
    }
}
// @lc code=end

