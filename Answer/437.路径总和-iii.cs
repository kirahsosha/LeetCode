/*
 * @lc app=leetcode.cn id=437 lang=csharp
 *
 * [437] 路径总和 III
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
    public int PathSum(TreeNode root, int targetSum)
    {
        return CheckRoot(root, targetSum, new List<long>());
    }

    private int CheckRoot(TreeNode root, int targetSum, List<long> parentSum)
    {
        var count = 0;
        if (root == null) return 0;
        parentSum.Add(0);
        for (int i = 0; i < parentSum.Count; i++)
        {
            parentSum[i] += root.val;
            if (parentSum[i] == targetSum) count++;
        }
        var leftSum = CheckRoot(root.left, targetSum, new List<long>(parentSum));
        var rightSum = CheckRoot(root.right, targetSum, new List<long>(parentSum));
        return count + leftSum + rightSum;
    }
}
// @lc code=end

