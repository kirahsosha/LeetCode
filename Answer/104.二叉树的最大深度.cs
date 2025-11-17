/*
 * @lc app=leetcode.cn id=104 lang=csharp
 *
 * [104] 二叉树的最大深度
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
    public int MaxDepth(TreeNode root) {
        if(root == null) return 0;
        Queue<TreeNode> tree = new Queue<TreeNode>{};
        Queue<int> deep = new Queue<int>{};
        tree.Enqueue(root);
        deep.Enqueue(1);
        TreeNode t;
        int d = 1;
        while(tree.Count != 0)
        {
            t = tree.Dequeue();
            d = deep.Dequeue();
            if(t.left != null)
            {
                tree.Enqueue(t.left);
                deep.Enqueue(d + 1);
            }
            if(t.right != null)
            {
                tree.Enqueue(t.right);
                deep.Enqueue(d + 1);
            }
        }
        return d;
    }
}
// @lc code=end

