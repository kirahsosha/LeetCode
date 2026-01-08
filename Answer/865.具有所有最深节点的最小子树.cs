/*
 * @lc app=leetcode.cn id=865 lang=csharp
 *
 * [865] 具有所有最深节点的最小子树
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
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        var node = Dfs(root, 0);
        return node.Item1;

        (TreeNode, int) Dfs(TreeNode node, int depth)
        {
            if (node == null)
            {
                return (node, depth);
            }
            var left = Dfs(node.left, depth + 1);
            var right = Dfs(node.right, depth + 1);
            if (left.Item1 != null && right.Item1 != null)
            {
                if (left.Item2 > right.Item2)
                {
                    return left;
                }
                else if (left.Item2 < right.Item2)
                {
                    return right;
                }
                else
                {
                    return (node, left.Item2);
                }
            }
            else if (left.Item1 != null)
            {
                return left;
            }
            else if (right.Item1 != null)
            {
                return right;
            }
            else
            {
                return (node, depth);
            }
        }
    }
}
// @lc code=end

