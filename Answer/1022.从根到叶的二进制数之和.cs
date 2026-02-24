/*
 * @lc app=leetcode.cn id=1022 lang=csharp
 *
 * [1022] 从根到叶的二进制数之和
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
    public static int MOD = 1000000007;

    public int SumRootToLeaf(TreeNode root)
    {
        int search(TreeNode t, int n)
        {
            n = (2 * n + t.val) % MOD;
            int sum = 0;
            if (t.left != null)
            {
                sum += search(t.left, n);
            }
            if (t.right != null)
            {
                sum += search(t.right, n);
            }
            if (t.left == null && t.right == null)
            {
                sum = n;
            }
            return sum % MOD;
        }

        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;
        return search(root, 0);
    }
}
// @lc code=end

