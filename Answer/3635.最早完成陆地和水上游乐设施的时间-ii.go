import "math"

/*
 * @lc app=leetcode.cn id=3635 lang=golang
 *
 * [3635] 最早完成陆地和水上游乐设施的时间 II
 */

// @lc code=start
func earliestFinishTime(landStartTime []int, landDuration []int, waterStartTime []int, waterDuration []int) int {
	landWater := solve(landStartTime, landDuration, waterStartTime, waterDuration)
	waterLand := solve(waterStartTime, waterDuration, landStartTime, landDuration)
	return min(landWater, waterLand)
}

func solve(landStartTime, landDuration, waterStartTime, waterDuration []int) int {
	minFinish := math.MaxInt
	for i, start := range landStartTime {
		minFinish = min(minFinish, start+landDuration[i])
	}

	res := math.MaxInt
	for i, start := range waterStartTime {
		res = min(res, max(start, minFinish)+waterDuration[i])
	}
	return res
}

// @lc code=end
