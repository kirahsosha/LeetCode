/*
 * @lc app=leetcode.cn id=199 lang=csharp
 *
 * [199] 二叉树的右视图
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
    public IList<int> r = new List<int>{};

    public int search(TreeNode t, int deep, int max)
    {
        if(deep > max)
        {
            r.Add(t.val);
            max = deep;
        }
        if(t.right != null)
        {
            max = search(t.right, deep + 1, max);
        }
        if(t.left != null)
        {
            max = search(t.left, deep + 1, max);
        }
        return max;
    }

    public IList<int> RightSideView(TreeNode root) {
        if(root == null) return r;
        search(root, 1, 0);
        return r;
    }
}
// @lc code=end

