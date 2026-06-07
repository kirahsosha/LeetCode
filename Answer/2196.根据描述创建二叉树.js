/*
 * @lc app=leetcode.cn id=2196 lang=javascript
 *
 * [2196] 根据描述创建二叉树
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
 * @param {number[][]} descriptions
 * @return {TreeNode}
 */
var createBinaryTree = function (descriptions) {
    var nodes = {};
    var hasParent = {};
    var vals = [];
    for (var i = 0; i < descriptions.length; i++) {
        var p = descriptions[i][0];
        var c = descriptions[i][1];
        var isLeft = descriptions[i][2];
        if (!nodes[p]) {
            nodes[p] = new TreeNode(p);
            vals.push(p);
        }
        if (!nodes[c]) {
            nodes[c] = new TreeNode(c);
            vals.push(c);
        }
        if (isLeft == 1) {
            nodes[p].left = nodes[c];
        } else {
            nodes[p].right = nodes[c];
        }
        hasParent[c] = true;
    }
    for (var i = 0; i < vals.length; i++) {
        if (!hasParent[vals[i]]) {
            return nodes[vals[i]];
        }
    }
    return null;
};
// @lc code=end
