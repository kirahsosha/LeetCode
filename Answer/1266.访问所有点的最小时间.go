/*
 * @lc app=leetcode.cn id=1266 lang=golang
 *
 * [1266] 访问所有点的最小时间
 */

// @lc code=start
import "math"

func minTimeToVisitAllPoints(points [][]int) int {
	n := len(points)
	if n == 1 {
		return 0
	}
	res := 0
	x1 := points[0][0]
	y1 := points[0][1]
	for i := 1; i < n; i++ {
		x := points[i][0]
		y := points[i][1]
		res += int(math.Max(math.Abs(float64(x)-float64(x1)), math.Abs(float64(y)-float64(y1))))
		x1 = x
		y1 = y
	}
	return res
}

// @lc code=end
