/*
 * @lc app=leetcode.cn id=1975 lang=golang
 *
 * [1975] 最大方阵和
 */

// @lc code=start
func maxMatrixSum(matrix [][]int) int64 {
	n := len(matrix)
	sumPos := int64(0)
	sumNeg := int64(0)
	maxNeg := -100001
	minPos := 100001
	countPos := 0
	countNeg := 0
	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			k := matrix[i][j]
			if k >= 0 {
				countPos += 1
				sumPos += int64(k)
				minPos = min(minPos, k)
			} else {
				countNeg += 1
				sumNeg -= int64(k)
				maxNeg = max(maxNeg, k)
			}
		}
	}
	if countNeg%2 == 0 {
		return sumPos + sumNeg
	} else if countPos == 0 {
		return sumPos + sumNeg + 2*int64(maxNeg)
	} else {
		return max(sumPos+sumNeg+2*int64(maxNeg), sumPos+sumNeg-2*int64(minPos))
	}
}

// @lc code=end
