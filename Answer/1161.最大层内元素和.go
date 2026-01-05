/*
 * @lc app=leetcode.cn id=1161 lang=golang
 *
 * [1161] 最大层内元素和
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
func maxLevelSum(root *TreeNode) int {
	max := 0
	sum := []int{}

	var dfs func(*TreeNode, int)
	dfs = func(root *TreeNode, level int) {
		if len(sum) > level {
			sum[level] += root.Val
		} else {
			sum = append(sum, root.Val)
		}
		if root.Left != nil {
			dfs(root.Left, level+1)
		}
		if root.Right != nil {
			dfs(root.Right, level+1)
		}
	}

	dfs(root, 0)
	for i := 0; i < len(sum); i++ {
		if sum[i] > sum[max] {
			max = i
		}
	}
	return max + 1
}

// @lc code=end
