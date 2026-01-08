/*
 * @lc app=leetcode.cn id=865 lang=golang
 *
 * [865] 具有所有最深节点的最小子树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * type TreeNode struct {
 *     Val int
 *     Left *TreeNode
 *     Right *TreeNode
 * }
 */
func subtreeWithAllDeepest(root *TreeNode) *TreeNode {

	var dfs func(*TreeNode, int) (*TreeNode, int)
	dfs = func(node *TreeNode, depth int) (*TreeNode, int) {
		if node == nil {
			return node, depth
		}
		leftNode, leftDepth := dfs(node.Left, depth+1)
		rightNode, rightDepth := dfs(node.Right, depth+1)
		if leftNode != nil && rightNode != nil {
			if leftDepth > rightDepth {
				return leftNode, leftDepth
			} else if leftDepth < rightDepth {
				return rightNode, rightDepth
			} else {
				return node, leftDepth
			}
		} else if leftNode != nil {
			return leftNode, leftDepth
		} else if rightNode != nil {
			return rightNode, rightDepth
		} else {
			return node, depth
		}
	}

	var node, _ = dfs(root, 0)
	return node
}

// @lc code=end
