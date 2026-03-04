/*
 * @lc app=leetcode.cn id=1582 lang=golang
 *
 * [1582] 二进制矩阵中的特殊位置
 */

// @lc code=start
func numSpecial(mat [][]int) int {
	m := len(mat)
	n := len(mat[0])
	rows := make([]int, m)
	res := 0
	for i := 0; i < m; i++ {
		first := -1
		for j := 0; j < n; j++ {
			if mat[i][j] == 1 {
				rows[i] = j
				if first == -1 {
					first = j
				}
			}
		}
		if first == rows[i] {
			a := -1
			b := -1
			for j := 0; j < m; j++ {
				if mat[j][first] == 1 {
					if a == -1 {
						a = j
					} else {
						b = j
						break
					}
				}
			}
			if a != -1 && b == -1 {
				res += 1
			}
		}
	}
	return res
}

// @lc code=end
