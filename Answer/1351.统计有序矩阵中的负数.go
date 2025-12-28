/*
 * @lc app=leetcode.cn id=1351 lang=golang
 *
 * [1351] 统计有序矩阵中的负数
 */

// @lc code=start
func countNegatives(grid [][]int) int {
	m := len(grid)
	n := len(grid[0])
	ans := 0
	j := 0
	for i := m - 1; i >= 0; i-- {
		for j < n {
			if grid[i][j] < 0 {
				ans += n - j
				break
			}
			j++
		}
	}
	return ans
}

// @lc code=end
