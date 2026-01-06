
import java.util.HashSet;

/*
 * @lc app=leetcode.cn id=1339 lang=java
 *
 * [1339] 分裂二叉树的最大乘积
 */
// @lc code=start
/**
 * Definition for a binary tree node. public class TreeNode { int val; TreeNode
 * left; TreeNode right; TreeNode() {} TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) { this.val = val; this.left
 * = left; this.right = right; } }
 */
class Solution {

    public int maxProduct(TreeNode root) {
        int MOD = 1000000007;
        HashSet<Integer> sums = new HashSet<>();
        var total = Dfs(root, sums);
        var mi = total;
        long res = 0;
        for (int item : sums) {
            if (Math.abs(total - item - item) < mi) {
                res = item;
                mi = Math.abs(total - item - item);
            }
        }
        return (int) (res * (total - res) % MOD);
    }

    private int Dfs(TreeNode node, HashSet<Integer> sums) {
        var left = 0;
        var right = 0;
        if (node.left != null) {
            left = Dfs(node.left, sums);
            sums.add(left);
        }
        if (node.right != null) {
            right = Dfs(node.right, sums);
            sums.add(right);
        }
        return node.val + left + right;
    }
}
// @lc code=end

