/*
 * @lc app=leetcode.cn id=114 lang=csharp
 *
 * [114] 二叉树展开为链表
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
    public TreeNode treeToList(TreeNode node)
    {
        TreeNode lt = node.left;
        node.left = null;
        TreeNode rt = node.right;
        node.right = null;
        if(lt != null && rt != null)
        {
            node.right = lt;
            lt = treeToList(lt);
            lt.right = rt;
            rt = treeToList(rt);
            return rt;
        }
        else if(lt != null)
        {
            node.right = lt;
            lt = treeToList(lt);
            return lt;
        }
        else if(rt != null)
        {
            node.right = rt;
            rt = treeToList(rt);
            return rt;
        }
        else
        {
            return node;
        }
    }

    public void Flatten(TreeNode root) {
        if(root == null) return;
        treeToList(root);
        return;
    }
}
// @lc code=end

