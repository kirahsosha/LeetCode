/*
 * @lc app=leetcode.cn id=2553 lang=golang
 *
 * [2553] 分割数组中数字的数位
 */

// @lc code=start
func separateDigits(nums []int) []int {
	total := 0
	for _, num := range nums {
		for x := num; x > 0; x /= 10 {
			total++
		}
	}
	ans := make([]int, 0, total)
	var buf [6]int // 1 <= nums[i] <= 1e5，最多6位
	for _, num := range nums {
		n := 0
		for x := num; x > 0; x /= 10 {
			buf[n] = x % 10
			n++
		}
		for i := n - 1; i >= 0; i-- {
			ans = append(ans, buf[i])
		}
	}
	return ans
}
// @lc code=end

