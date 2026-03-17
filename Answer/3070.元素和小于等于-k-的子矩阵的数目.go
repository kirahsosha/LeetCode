/*
 * @lc app=leetcode.cn id=3070 lang=golang
 *
 * [3070] 元素和小于等于 k 的子矩阵的数目
 */

// @lc code=start
func countSubmatrices(grid [][]int, k int) int {
	m := len(grid)
	n := len(grid[0])
	pre := make([]int, n)
	res := 0
	for i := 0; i < m; i++ {
		sum := 0
		for j := 0; j < n; j++ {
			pre[j] += grid[i][j]
			sum += pre[j]
			if sum <= k {
				res++
			} else {
				n = j
				break
			}
		}
	}
	return res
}

// @lc code=end
