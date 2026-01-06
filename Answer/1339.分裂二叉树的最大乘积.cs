/*
 * @lc app=leetcode.cn id=1339 lang=csharp
 *
 * [1339] 分裂二叉树的最大乘积
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
    public int MaxProduct(TreeNode root)
    {
        int MOD = 1000000007;
        var sums = new HashSet<int>();
        var total = Dfs(root);
        var mi = total;
        long res = 0;
        foreach (var item in sums)
        {
            if (Math.Abs(total - item - item) < mi)
            {
                res = item;
                mi = Math.Abs(total - item - item);
            }
        }
        return (int)(res * (total - res) % MOD);

        int Dfs(TreeNode node)
        {
            var left = 0;
            var right = 0;
            if (node.left != null)
            {
                left = Dfs(node.left);
                sums.Add(left);
            }
            if (node.right != null)
            {
                right = Dfs(node.right);
                sums.Add(right);
            }
            return node.val + left + right;
        }
    }
}
// @lc code=end

