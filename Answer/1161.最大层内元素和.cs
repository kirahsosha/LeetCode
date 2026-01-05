/*
 * @lc app=leetcode.cn id=1161 lang=csharp
 *
 * [1161] 最大层内元素和
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
    public int MaxLevelSum(TreeNode root)
    {
        var max = 0;
        var sum = new List<int>();
        Dfs(root, 0);
        for (int i = 0; i < sum.Count; i++)
        {
            if (sum[i] > sum[max])
            {
                max = i;
            }
        }
        return max + 1;

        void Dfs(TreeNode root, int level)
        {
            if (root != null)
            {
                if (sum.Count > level)
                {
                    sum[level] += root.val;
                }
                else
                {
                    sum.Add(root.val);
                }
                Dfs(root.left, level + 1);
                Dfs(root.right, level + 1);
            }
        }
    }
}
// @lc code=end

