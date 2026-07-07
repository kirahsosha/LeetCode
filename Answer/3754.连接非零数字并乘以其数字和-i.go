/*
 * @lc app=leetcode.cn id=3754 lang=golang
 *
 * [3754] 连接非零数字并乘以其数字和 I
 */

// @lc code=start
func sumAndMultiply(n int) int64 {
	x := 0
	pow := 1
	sum := 0
	for n > 0 {
		d := n % 10
		if d != 0 {
			x += d * pow
			pow *= 10
			sum += d
		}
		n /= 10
	}
	return int64(x) * int64(sum)
}

// @lc code=end
