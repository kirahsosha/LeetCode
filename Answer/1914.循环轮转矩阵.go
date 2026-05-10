/*
 * @lc app=leetcode.cn id=1914 lang=golang
 *
 * [1914] 循环轮转矩阵
 */

// @lc code=start
func rotateGrid(grid [][]int, k int) [][]int {
    // 层数：min(m,n)/2
	// 每层的元素个数：2*(m+n-4*i-2)
	// 每层旋转 k 次：k % (2*(m+n-4*i-2))
	// 旋转：将每层的元素按顺序放入一个数组中，旋转后再放回原位
	m, n := len(grid), len(grid[0])
	layers := min(m, n) / 2
	for i := 0; i < layers; i++ {
		layerSize := 2 * (m + n - 4*i - 2)
		rotations := k % layerSize
		if rotations == 0 {
			continue
		}
		layer := make([]int, layerSize)
		idx := 0
		// 逆时针旋转
		for j := i; j < n-i; j++ {
			layer[idx] = grid[i][j]
			idx++
		}
		for j := i + 1; j < m-i-1; j++ {
			layer[idx] = grid[j][n-i-1]
			idx++
		}
		for j := n - i - 1; j >= i; j-- {
			layer[idx] = grid[m-i-1][j]
			idx++
		}
		for j := m - i - 2; j > i; j-- {
			layer[idx] = grid[j][i]
			idx++
		}
		// 旋转后放回原位
		idx = 0
		for j := i; j < n-i; j++ {
			grid[i][j] = layer[(idx+rotations)%layerSize]
			idx++
		}
		for j := i + 1; j < m-i-1; j++ {
			grid[j][n-i-1] = layer[(idx+rotations)%layerSize]
			idx++
		}
		for j := n - i - 1; j >= i; j-- {
			grid[m-i-1][j] = layer[(idx+rotations)%layerSize]
			idx++
		}
		for j := m - i - 2; j > i; j-- {
			grid[j][i] = layer[(idx+rotations)%layerSize]
			idx++
		}
	}
	return grid
}
// @lc code=end

