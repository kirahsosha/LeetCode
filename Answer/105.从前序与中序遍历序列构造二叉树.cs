/*
 * @lc app=leetcode.cn id=105 lang=csharp
 *
 * [105] 从前序与中序遍历序列构造二叉树
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
    public TreeNode Helper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if(preStart > preorder.Length - 1 || inStart > inEnd) return null;

            TreeNode root = new TreeNode(preorder[preStart]);
            int inIndex = 0;
            for(int i = 0; i < inorder.Length; i++)
            {
                if(inorder[i] == root.val)
                {
                    inIndex = i;
                    break;
                }
            }
            root.left = Helper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
            root.right = Helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder);
            return root;
        }

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
            return Helper(0, 0, inorder.Length - 1, preorder, inorder);
        }
}
// @lc code=end

