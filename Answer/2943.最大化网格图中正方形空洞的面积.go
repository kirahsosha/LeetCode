import "sort"

/*
 * @lc app=leetcode.cn id=2943 lang=golang
 *
 * [2943] 最大化网格图中正方形空洞的面积
 */

// @lc code=start
func maximizeSquareHoleArea(n int, m int, hBars []int, vBars []int) int {
	sort.Ints(hBars)
	hMax := 1
	left := 1
	right := 2
	for _, bar := range hBars {
		if bar == right {
			right = bar + 1
		} else {
			left = bar - 1
			right = bar + 1
		}
		hMax = max(hMax, right-left)
	}

	sort.Ints(vBars)
	vMax := 1
	left = 1
	right = 2
	for _, bar := range vBars {
		if bar == right {
			right = bar + 1
		} else {
			left = bar - 1
			right = bar + 1
		}
		vMax = max(vMax, right-left)
	}

	l := min(hMax, vMax)
	return l * l
}

// @lc code=end
