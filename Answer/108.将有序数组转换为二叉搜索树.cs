/*
 * @lc app=leetcode.cn id=108 lang=csharp
 *
 * [108] 将有序数组转换为二叉搜索树
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
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return GetChildBST(nums, 0, nums.Length - 1);
    }
    private TreeNode GetChildBST(int[] nums, int left, int right)
    {
        if (left < 0 || right > nums.Length - 1 || left > right) return null;
        var n = (left + right) / 2;
        var root = new TreeNode
        {
            val = nums[n],
            left = GetChildBST(nums, left, n - 1),
            right = GetChildBST(nums, n + 1, right)
        };
        return root;
    }
}
// @lc code=end

