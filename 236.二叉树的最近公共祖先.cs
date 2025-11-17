/*
 * @lc app=leetcode.cn id=236 lang=csharp
 *
 * [236] 二叉树的最近公共祖先
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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        Queue<TreeNode> qTree = new Queue<TreeNode>{};
        Stack<TreeNode> sTree = new Stack<TreeNode>{};
        //使用辅助队列层次遍历全体入栈
        qTree.Enqueue(root);
        while(qTree.Count != 0)
        {
            TreeNode t = qTree.Dequeue();
            if(t.left != null) qTree.Enqueue(t.left);
            if(t.right != null) qTree.Enqueue(t.right);
            sTree.Push(t);
        }
        TreeNode p1 = p, q1 = q;
        //顺序出栈并找到p和q的最近公共祖先
        while(sTree.Count != 0)
        {
            TreeNode t = sTree.Pop();
            if(t == p1)
            {
                if(t.left == q1 || t.right == q1) return t;
                p1 = t;
            }
            if(t == q1)
            {
                if(t.left == p1 || t.right == p1) return t;
                q1 = t;
            }
            if(t.left == p1)
            {
                if(t.right == q1) return t;
                p1 = t;
            }
            if(t.right == p1)
            {
                if(t.left == q1) return t;
                p1 = t;
            }
            if(t.left == q1)
            {
                if(t.right == p1) return t;
                q1 = t;
            }
            if(t.right == q1)
            {
                if(t.left == p1) return t;
                q1 = t;
            }
        }
        return root;
    }
}
// @lc code=end

