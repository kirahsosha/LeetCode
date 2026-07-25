/*
 * @lc app=leetcode.cn id=3536 lang=golang
 *
 * [3536] 两个数字的最大乘积
 */

// @lc code=start
func maxProduct(n int) int {
	digit := 0
	ans := 0
	for n > 0 {
		d := n % 10
		if d*digit > ans {
			ans = d * digit
		}
		if d > digit {
			digit = d
		}
		n /= 10
	}
	return ans
}

// @lc code=end
