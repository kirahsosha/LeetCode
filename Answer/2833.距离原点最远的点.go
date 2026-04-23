/*
 * @lc app=leetcode.cn id=2833 lang=golang
 *
 * [2833] 距离原点最远的点
 */

// @lc code=start
func furthestDistanceFromOrigin(moves string) int {
	left := 0
	right := 0
	for _, c := range moves {
		if c == 'L' {
			left++
			right--
		} else if c == 'R' {
			right++
			left--
		} else {
			left++
			right++
		}
	}
	return max(left, right)
}

// @lc code=end
