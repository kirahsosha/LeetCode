/*
 * @lc app=leetcode.cn id=538 lang=csharp
 *
 * [538] 把二叉搜索树转换为累加树
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
    public int search(TreeNode T, int count)
    {
        if(T == null) return count;
        //遍历修改右子树, 并返回累加和
        count = search(T.right, count);
        //修改当前节点值, 以及累加和
        T.val += count;
        count = T.val;
        //遍历修改右子树, 并返回累加和
        count = search(T.left, count);
        return count;
    }

    //从最大值节点到最小值节点遍历, 记录累加值, 并修改每个节点的值
    public TreeNode ConvertBST(TreeNode root) {
        search(root, 0);
        return root;
    }
}
// @lc code=end

