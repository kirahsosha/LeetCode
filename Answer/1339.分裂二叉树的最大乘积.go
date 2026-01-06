import "math"

/*
 * @lc app=leetcode.cn id=1339 lang=golang
 *
 * [1339] 分裂二叉树的最大乘积
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
func maxProduct(root *TreeNode) int {
	MOD := int64(1000000007)
	sums := make(map[int]bool)

	var dfs func(*TreeNode) int
	dfs = func(node *TreeNode) int {
		left := 0
		right := 0
		if node.Left != nil {
			left = dfs(node.Left)
			sums[left] = true
		}
		if node.Right != nil {
			right = dfs(node.Right)
			sums[right] = true
		}
		return node.Val + left + right
	}

	total := dfs(root)
	mi := total
	res := int64(0)
	for item, _ := range sums {
		i := int(math.Abs(float64(total - item - item)))
		if i < mi {
			res = int64(item)
			mi = i
		}
	}
	return int(res * (int64(total) - res) % MOD)
}

// @lc code=end
