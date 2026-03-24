/*
 * @lc app=leetcode.cn id=3643 lang=golang
 *
 * [3643] 垂直翻转子矩阵
 */

// @lc code=start
func reverseSubmatrix(grid [][]int, x int, y int, k int) [][]int {
	for i := x; i < x+k/2; i++ {
		t := 2*x + k - i - 1
		for j := y; j < y+k; j++ {
			temp := grid[i][j]
			grid[i][j] = grid[t][j]
			grid[t][j] = temp
		}
	}
	return grid
}

// @lc code=end
