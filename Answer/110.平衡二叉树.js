/*
 * @lc app=leetcode.cn id=110 lang=javascript
 *
 * [110] 平衡二叉树
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
 * @return {boolean}
 */
var isBalanced = function (root) {
    return GetDepth(root).Check;

    function GetDepth(node) {
        var res = { Check: true, Depth: 0 };
        if (node === null || node === undefined) {
            return res;
        }
        res.Depth = 1;
        var left = GetDepth(node.left);
        var right = GetDepth(node.right);
        if (left.Check && right.Check) {
            res.Depth = Math.max(left.Depth, right.Depth) + 1;
            res.Check = Math.abs(left.Depth - right.Depth) <= 1;
            return res;
        }
        res.Check = false;
        return res;
    }
};
// @lc code=end

