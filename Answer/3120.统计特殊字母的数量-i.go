/*
 * @lc app=leetcode.cn id=3120 lang=golang
 *
 * [3120] 统计特殊字母的数量 I
 */

// @lc code=start
func numberOfSpecialChars(word string) int {
	var lowerMask, upperMask uint32
	for i := 0; i < len(word); i++ {
		c := word[i]
		if c >= 'a' && c <= 'z' {
			lowerMask |= 1 << (c - 'a')
		} else if c >= 'A' && c <= 'Z' {
			upperMask |= 1 << (c - 'A')
		}
	}

	common := lowerMask & upperMask
	ans := 0
	for common > 0 {
		ans += int(common & 1)
		common >>= 1
	}
	return ans
}

// @lc code=end
