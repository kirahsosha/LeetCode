/*
 * @lc app=leetcode.cn id=66 lang=golang
 *
 * [66] 加一
 */

// @lc code=start
func plusOne(digits []int) []int {
	n := len(digits)
	if n == 1 && digits[0] == 0 {
		digits[0] = 1
		return digits
	}
	t := 1
	for i := n - 1; i >= 0; i-- {
		digits[i] += t
		t = 0
		if digits[i] == 10 {
			digits[i] = 0
			t = 1
		}
		if t == 0 {
			break
		}
	}
	if t == 1 {
		return append([]int{1}, digits...)
	} else {
		return digits
	}
}

// @lc code=end
