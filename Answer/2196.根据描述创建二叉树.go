/*
 * @lc app=leetcode.cn id=2196 lang=golang
 *
 * [2196] 根据描述创建二叉树
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
func createBinaryTree(descriptions [][]int) *TreeNode {
	nodes := make([]*TreeNode, 100001)
	hasParent := make([]bool, 100001)
	for _, d := range descriptions {
		p, c, isLeft := d[0], d[1], d[2]
		if nodes[p] == nil {
			nodes[p] = &TreeNode{Val: p}
		}
		if nodes[c] == nil {
			nodes[c] = &TreeNode{Val: c}
		}
		if isLeft == 1 {
			nodes[p].Left = nodes[c]
		} else {
			nodes[p].Right = nodes[c]
		}
		hasParent[c] = true
	}
	for i := 1; i <= 100000; i++ {
		if nodes[i] != nil && !hasParent[i] {
			return nodes[i]
		}
	}
	return nil
}

// @lc code=end
