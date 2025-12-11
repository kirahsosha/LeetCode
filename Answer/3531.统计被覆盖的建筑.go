/*
 * @lc app=leetcode.cn id=3531 lang=golang
 *
 * [3531] 统计被覆盖的建筑
 */

// @lc code=start
func countCoveredBuildings(n int, buildings [][]int) int {
	//Key：横坐标；Value：纵坐标范围
	ver := make(map[int][2]int)
	//Key：纵坐标；Value：横坐标范围
	hor := make(map[int][2]int)
	for _, building := range buildings {
		x := building[0]
		y := building[1]
		if existing, exists := ver[x]; exists {
			ver[x] = [2]int{int(math.Min(float64(existing[0]), float64(y))), int(math.Max(float64(existing[1]), float64(y)))}
		} else {
			ver[x] = [2]int{y, y}
		}

		if existing, exists := hor[y]; exists {
			hor[y] = [2]int{int(math.Min(float64(existing[0]), float64(x))), int(math.Max(float64(existing[1]), float64(x)))}
		} else {
			hor[y] = [2]int{x, x}
		}
	}
	res := 0
	for _, building := range buildings {
		x := building[0]
		y := building[1]
		if ver[x][0] < y && ver[x][1] > y && hor[y][0] < x && hor[y][1] > x {
			res += 1
		}
	}
	return res
}

// @lc code=end

