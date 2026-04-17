/*
 * @lc app=leetcode.cn id=3783 lang=golang
 *
 * [3783] 整数的镜像距离
 */

// @lc code=start
func mirrorDistance(n int) int {
	rev := 0
	for x := n; x > 0; x /= 10 {
		rev = rev*10 + x%10
	}
	if rev >= n {
		return rev - n
	}
	return n - rev
}

// @lc code=end
