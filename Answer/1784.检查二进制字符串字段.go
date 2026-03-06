/*
 * @lc app=leetcode.cn id=1784 lang=golang
 *
 * [1784] 检查二进制字符串字段
 */

// @lc code=start
func checkOnesSegment(s string) bool {
	res := false
	hasZero := false
	for _, c := range s {
		if c == '1' && !res {
			res = true
		} else if c == '0' && res {
			hasZero = true
		} else if c == '1' && hasZero {
			return false
		}
	}
	return res
}

// @lc code=end
