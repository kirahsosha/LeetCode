/*
 * @lc app=leetcode.cn id=1758 lang=golang
 *
 * [1758] 生成交替二进制字符串的最少操作数
 */

// @lc code=start
func minOperations(s string) int {
	res := 0
	n := len(s)
	for i, c := range s {
		if int(c-'0') != i%2 {
			res++
		}
	}
	if res > n-res {
		return n - res
	}
	return res
}

// @lc code=end
