/*
 * @lc app=leetcode.cn id=1861 lang=golang
 *
 * [1861] 旋转盒子
 */

// @lc code=start
func rotateTheBox(boxGrid [][]byte) [][]byte {
	m, n := len(boxGrid), len(boxGrid[0])
	ans := make([][]byte, n)
	for i := range ans {
		ans[i] = bytes.Repeat([]byte{'.'}, m)
	}

	for i, row := range boxGrid {
		k := n - 1
		for j := n - 1; j >= 0; j-- {
			if row[j] == '*' {
				ans[j][m-1-i] = '*'
				k = j - 1
			} else if row[j] == '#' {
				ans[k][m-1-i] = '#'
				k--
			}
		}
	}

	return ans
}
// @lc code=end

