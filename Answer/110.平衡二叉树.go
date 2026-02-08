/*
 * @lc app=leetcode.cn id=110 lang=golang
 *
 * [110] 平衡二叉树
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
func isBalanced(root *TreeNode) bool {
	var getDepth func(node *TreeNode) int
	getDepth = func(node *TreeNode) int {
		depth := 0
		if node == nil {
			return 0
		}
		left := getDepth(node.Left)
		right := getDepth(node.Right)
		if left >= 0 && right >= 0 {
			depth = int(math.Max(float64(left), float64(right))) + 1
			if int(math.Abs(float64(left) - float64(right))) <= 1 {
				return depth
			} else {
				return -1
			}
		}
		return -1
	}

	return getDepth(root) >= 0
}
// @lc code=end

