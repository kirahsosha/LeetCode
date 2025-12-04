/*
 * @lc app=leetcode.cn id=2211 lang=golang
 *
 * [2211] 统计道路上的碰撞次数
 */

// @lc code=start
func countCollisions(directions string) int {
	//L：state < 0，忽略；state >= 0，更新res += state + 1，state = 0
	//S：state < 0，更新state = 0；state >= 0，更新res += state，state = 0
	//R：state <= 0，更新state = 1；state > 0，更新state += 1
	state := -1
	res := 0
	for _, c := range directions {
		switch c {
		case 'L':
			if state >= 0 {
				res += state + 1
				state = 0
			}
		case 'S':
			if state < 0 {
				state = 0
			} else {
				res += state
				state = 0
			}
		case 'R':
			if state <= 0 {
				state = 1
			} else {
				state += 1
			}
		}
	}
	return res
}

// @lc code=end

