/*
 * @lc app=leetcode.cn id=2196 lang=typescript
 *
 * [2196] 根据描述创建二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * class TreeNode {
 *     val: number
 *     left: TreeNode | null
 *     right: TreeNode | null
 *     constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.left = (left===undefined ? null : left)
 *         this.right = (right===undefined ? null : right)
 *     }
 * }
 */

function createBinaryTree(descriptions: number[][]): TreeNode | null {
    const nodes: Record<number, TreeNode> = {};
    const hasParent: Record<number, boolean> = {};
    const vals: number[] = [];
    for (let i = 0; i < descriptions.length; i++) {
        const p = descriptions[i][0];
        const c = descriptions[i][1];
        const isLeft = descriptions[i][2];
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
    for (let i = 0; i < vals.length; i++) {
        if (!hasParent[vals[i]]) {
            return nodes[vals[i]];
        }
    }
    return null;
}
// @lc code=end
