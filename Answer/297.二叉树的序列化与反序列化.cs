/*
 * @lc app=leetcode.cn id=297 lang=csharp
 *
 * [297] 二叉树的序列化与反序列化
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
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) return "[]";
        string ans = "[";
        Queue<TreeNode> tree = new Queue<TreeNode>{};
        tree.Enqueue(root);
        while(tree.Count() != 0)
        {
            TreeNode t = tree.Dequeue();
            if(t == null)
            {
                ans += "null,";
            }
            else
            {
                ans += t.val + ",";
                tree.Enqueue(t.left);
                tree.Enqueue(t.right);
            }
        }
        ans = ans.Substring(0, ans.Length - 1);
        ans += "]";
        return ans;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data == "[]") return null;
        data = data.Substring(1, data.Length - 2);
        string[] node = data.Split(',');
        TreeNode root = new TreeNode{
            left = null,
            right = null,
            val = int.Parse(node[0])
        };
        Queue<TreeNode> tree = new Queue<TreeNode>{};
        tree.Enqueue(root);
        int i = 1;
        while(i < node.Length)
        {
            TreeNode t = tree.Dequeue();
            if(node[i] != "null")
            {
                TreeNode l = new TreeNode{
                    left = null,
                    right = null,
                    val = int.Parse(node[i])
                };
                t.left = l;
                tree.Enqueue(l);
            }
            i++;
            if(i >= node.Length) break;
            if(node[i] != "null")
            {
                TreeNode r = new TreeNode{
                    left = null,
                    right = null,
                    val = int.Parse(node[i])
                };
                t.right = r;
                tree.Enqueue(r);
            }
            i++;
        }
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
// @lc code=end

