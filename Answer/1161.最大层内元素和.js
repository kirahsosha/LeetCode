/*
 * @lc app=leetcode.cn id=1161 lang=javascript
 *
 * [1161] 最大层内元素和
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
var maxLevelSum = function (root) {
    let max = 0;
    let sum = Array();
    Dfs(root, 0, sum);
    for (let i = 0; i < sum.length; i++) {
        if (sum[i] > sum[max]) {
            max = i;
        }
    }
    return max + 1;
};

/**
 * @param {TreeNode} root
 * @param {number} level
 * @param {Array} sum
 */
function Dfs(root, level, sum) {
    if (root != null) {
        if (sum.length > level) {
            sum[level] += root.val
        } else {
            sum.push(root.val);
        }
        Dfs(root.left, level + 1, sum);
        Dfs(root.right, level + 1, sum);
    }
}
// @lc code=end

