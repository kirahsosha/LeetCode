/*
 * @lc app=leetcode.cn id=3546 lang=golang
 *
 * [3546] 等和矩阵分割 I
 */

// @lc code=start
func canPartitionGrid(grid [][]int) bool {
	m := len(grid)
	n := len(grid[0])
	if m == 1 && n == 1 {
		return false
	}
	ver := make([]int64, m)
	hor := make([]int64, n)
	var sum int64 = 0
	for i := 0; i < m; i++ {
		if i > 0 {
			ver[i] = ver[i-1]
		}
		for j := 0; j < n; j++ {
			ver[i] += int64(grid[i][j])
			hor[j] += int64(grid[i][j])
			if i == m-1 && j > 0 {
				hor[j] += hor[j-1]
			}
			sum += int64(grid[i][j])
		}
	}
	if sum%2 != 0 {
		return false
	}
	half := sum / 2
	for _, v := range ver {
		if v == half {
			return true
		}
	}
	for _, v := range hor {
		if v == half {
			return true
		}
	}
	return false
}
// @lc code=end

