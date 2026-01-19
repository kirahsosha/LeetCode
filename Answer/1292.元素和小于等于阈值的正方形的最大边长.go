/*
 * @lc app=leetcode.cn id=1292 lang=golang
 *
 * [1292] 元素和小于等于阈值的正方形的最大边长
 */

// @lc code=start
func maxSideLength(mat [][]int, threshold int) int {
	m := len(mat)
	n := len(mat[0])
	pre := make([][]int, m)
	for i := 0; i < m; i++ {
		pre[i] = make([]int, n+1)
		pre[i][0] = 0
		for j := 0; j < n; j++ {
			pre[i][j+1] = pre[i][j] + mat[i][j]
		}
	}

	var check func(int) bool
	check = func(mid int) bool {
		for i := 0; i <= m-mid; i++ {
			for j := 0; j <= n-mid; j++ {
				total := 0
				for k := 0; k < mid; k++ {
					total += pre[i+k][j+mid] - pre[i+k][j]
				}
				if total <= threshold {
					return true
				}
			}
		}
		return false
	}

	left := 0
	right := min(m, n)
	for left < right {
		mid := left + (right-left+1)/2
		if check(mid) {
			left = mid
		} else {
			right = mid - 1
		}
	}
	return left

}

// @lc code=end
