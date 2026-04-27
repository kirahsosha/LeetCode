import "slices"

/*
 * @lc app=leetcode.cn id=1391 lang=golang
 *
 * [1391] 检查网格中是否存在有效路径
 */

// @lc code=start
func hasValidPath(grid [][]int) bool {
	var dirs = [7][2][2]int{
		{},
		{{0, -1}, {0, 1}},  // 1
		{{-1, 0}, {1, 0}},  // 2
		{{0, -1}, {1, 0}},  // 3
		{{0, 1}, {1, 0}},   // 4
		{{0, -1}, {-1, 0}}, // 5
		{{0, 1}, {-1, 0}},  // 6
	}

	var contains func(int, [2]int) bool
	contains = func(street int, dir [2]int) bool {
		return slices.Contains(dirs[street][:], dir)
	}

	m, n := len(grid), len(grid[0])
	vis := make([][]bool, m)
	for i := range vis {
		vis[i] = make([]bool, n)
	}

	var dfs func(int, int) bool
	dfs = func(x, y int) bool {
		if x == m-1 && y == n-1 {
			return true
		}
		vis[x][y] = true
		for _, d := range dirs[grid[x][y]] {
			i, j := x+d[0], y+d[1]
			if 0 <= i && i < m && 0 <= j && j < n && !vis[i][j] &&
				contains(grid[i][j], [2]int{-d[0], -d[1]}) && dfs(i, j) {
				return true
			}
		}
		return false
	}
	return dfs(0, 0)
}

// @lc code=end
