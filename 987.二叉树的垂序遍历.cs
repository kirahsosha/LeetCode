/*
 * @lc app=leetcode.cn id=987 lang=csharp
 *
 * [987] 二叉树的垂序遍历
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
    Dictionary<int, Dictionary<int, List<TreeNode>>> dic = new Dictionary<int, Dictionary<int, List<TreeNode>>>();

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            if (root.left == null && root.right == null)
            {
                ans.Add(new List<int>() { root.val });
                return ans;
            }
            DFS(root, 0, 0);
            foreach(var col in dic.OrderBy(p=>p.Key))
            {
                IList<int> temp = new List<int>();
                foreach(var row in col.Value.OrderBy(p=>p.Key))
                {
                    if(row.Value.Count == 1)
                    {
                        temp.Add(row.Value[0].val);
                    }
                    else
                    {
                        foreach(var n in row.Value.OrderBy(p=>p.val))
                        {
                            temp.Add(n.val);
                        }
                    }
                }
                ans.Add(temp);
            }
            return ans;
        }

        public void DFS(TreeNode node, int row, int col)
        {
            if (dic.TryGetValue(col, out var value))
            {
                if (value.TryGetValue(row, out var list))
                {
                    list.Add(node);
                }
                else
                {
                    value.Add(row, new List<TreeNode>() { node });
                }
            }
            else
            {
                dic.Add(col,
                    new Dictionary<int, List<TreeNode>>
                    {
                        { row, new List<TreeNode>() { node } }
                    });
            }
            if (node.left != null)
            {
                DFS(node.left, row + 1, col - 1);
            }

            if (node.right != null)
            {
                DFS(node.right, row + 1, col + 1);
            }
        }
}
// @lc code=end

