/*
 * @lc app=leetcode.cn id=657 lang=golang
 *
 * [657] 机器人能否返回原点
 */

// @lc code=start
func judgeCircle(moves string) bool {
	ver := 0
	hor := 0
	for _, move := range moves {
		switch move {
		case 'U':
			ver++
		case 'D':
			ver--
		case 'L':
			hor--
		case 'R':
			hor++
		}
	}
	return ver == 0 && hor == 0
}

// @lc code=end
