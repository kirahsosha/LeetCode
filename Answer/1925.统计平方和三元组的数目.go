/*
 * @lc app=leetcode.cn id=1925 lang=golang
 *
 * [1925] 统计平方和三元组的数目
 */

// @lc code=start
func countTriples(n int) int {
	//a^2 + b^2 = c^2
	//1 <= a, b, c <= n
	//a, b <= sqrt(n^2 / 2)
	maxa := int(math.Sqrt(float64(n * n / 2)))
	res := 0
	for a := 3; a <= maxa; a++ {
		maxb := int(math.Sqrt(float64(n*n - a*a)))
		for b := a + 1; b <= maxb; b++ {
			c2 := a*a + b*b
			c := int(math.Sqrt(float64(c2)))
			if c*c == c2 {
				res += 2
			}
		}
	}
	return res
}

// @lc code=end

