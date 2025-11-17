/*
 * @lc app=leetcode.cn id=113 lang=csharp
 *
 * [113] 路径总和 II
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
public class Solution {
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        IList<IList<int>> result = new List<IList<int>>();
        int s = 0;
        Dfs(s, targetSum, result, new List<int>(), root);
        return result;
    }

    private void Dfs(int sum, int target, IList<IList<int>> result, List<int> path, TreeNode node)
    {
        if (node != null)
        {
            sum += node.val;
            path.Add(node.val);
            if (node.left != null)
            {
                Dfs(sum, target, result, new List<int>(path), node.left);
            }
            if (node.right != null)
            {
                Dfs(sum, target, result, new List<int>(path), node.right);
            }
            if (node.left == null && node.right == null)
            {
                if (sum == target)
                {
                    result.Add(path);
                }
            }
        }
    }
}
// @lc code=end

