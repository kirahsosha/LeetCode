/*
 * @lc app=leetcode.cn id=2087 lang=golang
 *
 * [2087] 网格图中机器人回家的最小代价
 */

// @lc code=start
func minCost(startPos []int, homePos []int, rowCosts []int, colCosts []int) int {
	startRow := min(startPos[0], homePos[0])
	endRow := max(startPos[0], homePos[0])
	startCol := min(startPos[1], homePos[1])
	endCol := max(startPos[1], homePos[1])
	cost := 0
	for i := startRow; i <= endRow; i++ {
		cost += rowCosts[i]
	}
	for j := startCol; j <= endCol; j++ {
		cost += colCosts[j]
	}
	cost -= rowCosts[startPos[0]]
	cost -= colCosts[startPos[1]]
	return cost
}

// @lc code=end
