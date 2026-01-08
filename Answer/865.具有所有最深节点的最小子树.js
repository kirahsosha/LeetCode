/*
 * @lc app=leetcode.cn id=865 lang=javascript
 *
 * [865] 具有所有最深节点的最小子树
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
 * @return {TreeNode}
 */
var subtreeWithAllDeepest = function (root) {
    var node = Dfs(root, 0);
    return node[0];

    /**
     * @param {TreeNode} root
     * @param {number} root
     * @return {[TreeNode,number]}
     */
    function Dfs(node, depth) {
        if (node == null) {
            return [node, depth];
        }
        var left = Dfs(node.left, depth + 1);
        var right = Dfs(node.right, depth + 1);
        if (left[0] != null && right[0] != null) {
            if (left[1] > right[1]) {
                return left;
            }
            else if (left[1] < right[1]) {
                return right;
            }
            else {
                return [node, left[1]];
            }
        }
        else if (left[0] != null) {
            return left;
        }
        else if (right[0] != null) {
            return right;
        }
        else {
            return [node, depth];
        }
    }
};
// @lc code=end

