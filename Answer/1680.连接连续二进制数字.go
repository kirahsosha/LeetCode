/*
 * @lc app=leetcode.cn id=1680 lang=golang
 *
 * [1680] 连接连续二进制数字
 */

// @lc code=start
func concatenatedBinary(n int) int {
	MOD := 1000000007
	res := 0
	for i := 1; i <= n; i++ {
		t := i
		for t > 0 {
			t = t >> 1
			res = (res << 1) % MOD
		}
		res = (res + i) % MOD
	}
	return res
}

// @lc code=end
