/*
 * @lc app=leetcode.cn id=2946 lang=golang
 *
 * [2946] 循环移位后的矩阵相似检查
 */

// @lc code=start
func areSimilar(mat [][]int, k int) bool {
	n := len(mat[0])
	k %= n
	if k == 0 {
		return true
	}

	for i, row := range mat {
		if i&1 == 0 {
			for j, val := range row {
				if val != row[(j+k)%n] {
					return false
				}
			}
		} else {
			for j, val := range row {
				if val != row[(j-k+n)%n] {
					return false
				}
			}
		}
	}
	return true
}

// @lc code=end
