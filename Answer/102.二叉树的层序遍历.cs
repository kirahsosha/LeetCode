/*
 * @lc app=leetcode.cn id=102 lang=csharp
 *
 * [102] 二叉树的层序遍历
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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> ans = new List<IList<int>>{};
        if(root == null) return ans;
        Queue<TreeNode> breadth = new Queue<TreeNode>{};
        breadth.Enqueue(root);
        while(breadth.Count() != 0)
        {
            Queue<TreeNode> q = new Queue<TreeNode>{};
            TreeNode t;
            IList<int> list = new List<int>{};
            while(breadth.Count() != 0)
            {
                t = breadth.Dequeue();
                q.Enqueue(t);
            }
            while(q.Count() != 0)
            {
                t = q.Dequeue();
                list.Add(t.val);
                if(t.left != null) breadth.Enqueue(t.left);
                if(t.right != null) breadth.Enqueue(t.right);
            }
            ans.Add(list);
        }
        return ans;
    }
}
// @lc code=end

