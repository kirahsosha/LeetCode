/*
 * @lc app=leetcode.cn id=874 lang=golang
 *
 * [874] 模拟行走机器人
 */

// @lc code=start
func robotSim(commands []int, obstacles [][]int) int {
	direction := 0
	x, y := 0, 0
	distance := 0
	obstaclesSet := make(map[int]bool)
	for _, obstacle := range obstacles {
		obstaclesSet[obstacle[0]*60001+obstacle[1]] = true
	}

	move := func() {
		dx, dy := 0, 0
		switch direction {
		case 0:
			dy = 1
		case 1:
			dx = 1
		case 2:
			dy = -1
		case 3:
			dx = -1
		}
		if !obstaclesSet[(x+dx)*60001+(y+dy)] {
			x += dx
			y += dy
		}
		distance = max(distance, x*x+y*y)
	}

	for _, c := range commands {
		if c == -1 {
			direction = (direction + 1) % 4
		} else if c == -2 {
			direction = (direction + 3) % 4
		} else {
			for j := 0; j < c; j++ {
				move()
			}
		}
	}
	return distance
}

// @lc code=end
