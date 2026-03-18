/*
 * @lc app=leetcode.cn id=3212 lang=golang
 *
 * [3212] 统计 X 和 Y 频数相等的子矩阵数量
 */

// @lc code=start
func numberOfSubmatrices(grid [][]byte) int {
	m := len(grid)
	n := len(grid[0])
	cntX := make([]int, n)
	cntY := make([]int, n)
	res := 0
	for i := 0; i < m; i++ {
		var sumX = 0
		var sumY = 0
		for j := 0; j < n; j++ {
			if grid[i][j] == 'X' {
				cntX[j]++
			}
			if grid[i][j] == 'Y' {
				cntY[j]++
			}
			sumX += cntX[j]
			sumY += cntY[j]
			if sumX == sumY && sumX > 0 {
				res++
			}
		}
	}
	return res
}

// @lc code=end
