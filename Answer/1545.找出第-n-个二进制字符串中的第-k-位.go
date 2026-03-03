/*
 * @lc app=leetcode.cn id=1545 lang=golang
 *
 * [1545] 找出第 N 个二进制字符串中的第 K 位
 */

// @lc code=start
func findKthBit(n int, k int) byte {
	if k%2 > 0 {
		// 奇数
		return '0' + byte(k/2%2)
	} else {
		// 偶数
		k /= k & -k // 去掉 k 的尾零
		return '1' - byte(k/2%2)
	}
}

// @lc code=end
