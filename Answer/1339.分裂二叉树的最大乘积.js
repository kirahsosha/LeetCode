/*
 * @lc app=leetcode.cn id=1339 lang=javascript
 *
 * [1339] 分裂二叉树的最大乘积
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number}
 */
var maxProduct = function (root) {
    let MOD = 1000000007;
    let sums = new Set();
    let total = Dfs(root, sums);
    let mi = total;
    let res = 0;
    sums.forEach(item => {
        if (Math.abs(total - item - item) < mi) {
            res = item;
            mi = Math.abs(total - item - item);
        }
    });
    return res * (total - res) % MOD;

    /**
    * @param {TreeNode} root
    * @param {Set} sums
    * @return {number}
    */
    function Dfs(node, sums) {
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
};
// @lc code=end

