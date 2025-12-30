/*
 * @lc app=leetcode.cn id=840 lang=golang
 *
 * [840] 矩阵中的幻方
 */

// @lc code=start
func numMagicSquaresInside(grid [][]int) int {
	n := len(grid)
	m := len(grid[0])
	res := 0
	for i := 0; i <= n-3; i++ {
		for j := 0; j <= m-3; j++ {
			if isMagicSquare(grid, i, j) {
				res++
			}
		}
	}
	return res
}

func isMagicSquare(grid [][]int, x, y int) bool {
	target := 15
	seen := make(map[int]bool, 10)
	for i := 0; i < 3; i++ {
		for j := 0; j < 3; j++ {
			val := grid[x+i][y+j]
			if val < 1 || val > 9 || seen[val] {
				return false
			}
			seen[val] = true
		}
	}

	for i := 0; i < 3; i++ {
		rowSum := 0
		colSum := 0
		for j := 0; j < 3; j++ {
			rowSum += grid[x+i][y+j]
			colSum += grid[x+j][y+i]
		}
		if rowSum != target || colSum != target {
			return false
		}
		diag1 := grid[x][y] + grid[x+1][y+1] + grid[x+2][y+2]
		diag2 := grid[x][y+2] + grid[x+1][y+1] + grid[x+2][y]
		if diag1 != target || diag2 != target {
			return false
		}
	}
	return true
}

// @lc code=end
