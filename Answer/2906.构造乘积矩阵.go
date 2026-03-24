/*
 * @lc app=leetcode.cn id=2906 lang=golang
 *
 * [2906] 构造乘积矩阵
 */

// @lc code=start
func constructProductMatrix(grid [][]int) [][]int {
	mod := 12345
	n := len(grid)
	m := len(grid[0])
	left := make([]int64, n*m+1)
	right := make([]int64, n*m+1)
	left[0] = 1
	right[len(right)-1] = 1
	for i := 0; i < n; i++ {
		for j := 0; j < m; j++ {
			left[i*m+j+1] = left[i*m+j] * int64(grid[i][j]) % int64(mod)
		}
	}

	for i := n - 1; i >= 0; i-- {
		for j := m - 1; j >= 0; j-- {
			right[i*m+j] = right[i*m+j+1] * int64(grid[i][j]) % int64(mod)
		}
	}

	p := make([][]int, n)
	for i := 0; i < n; i++ {
		p[i] = make([]int, m)
		for j := 0; j < m; j++ {
			p[i][j] = int(left[i*m+j] * right[i*m+j+1] % int64(mod))
		}
	}

	return p
}

// @lc code=end
