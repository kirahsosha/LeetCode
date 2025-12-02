/*
 * @lc app=leetcode.cn id=3623 lang=golang
 *
 * [3623] 统计梯形的数目 I
 */

// @lc code=start
func countTrapezoids(points [][]int) int {
    MOD := 1000000007
	//key：纵坐标；value：线段数量
	dic := make(map[int]int)
	for _, point := range points {
		y := point[1]
		dic[y]++
	}
	res, side := 0, 0
	for _, point := range dic {
		edge := point * (point - 1) / 2
		res = (res + edge * side) % MOD
		side = (side + edge) % MOD
	}
	return res
}
// @lc code=end

