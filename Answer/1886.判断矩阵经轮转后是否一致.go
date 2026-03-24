/*
 * @lc app=leetcode.cn id=1886 lang=golang
 *
 * [1886] 判断矩阵经轮转后是否一致
 */

// @lc code=start
func findRotation(mat [][]int, target [][]int) bool {
	n := len(mat)
	r1, r2, r3, r4 := true, true, true, true
	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			if r1 && mat[i][j] != target[i][j] {
				r1 = false
			}
			if r2 && mat[i][j] != target[j][n-i-1] {
				r2 = false
			}
			if r3 && mat[i][j] != target[n-i-1][n-j-1] {
				r3 = false
			}
			if r4 && mat[i][j] != target[n-j-1][i] {
				r4 = false
			}
		}
	}
	return r1 || r2 || r3 || r4
}
// @lc code=end

