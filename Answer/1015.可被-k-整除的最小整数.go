/*
 * @lc app=leetcode.cn id=1015 lang=golang
 *
 * [1015] 可被 K 整除的最小整数
 */

// @lc code=start
func smallestRepunitDivByK(k int) int {
    s := make(map[int]bool)
	n := 0
	for i := 1; i <= k; i++ {
		n = (n * 10 + 1) % k
		if n == 0 {
			return i
		} else if s[n] {
			return -1
		} else {
			s[n] = true
		}
	}
	return -1
}
// @lc code=end

