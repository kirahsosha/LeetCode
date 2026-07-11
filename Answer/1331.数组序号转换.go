/*
 * @lc app=leetcode.cn id=1331 lang=golang
 *
 * [1331] 数组序号转换
 */

// @lc code=start
func arrayRankTransform(arr []int) []int {
	n := len(arr)
	type pair struct {
		val int
		idx int
	}
	pairs := make([]pair, n)
	for i, v := range arr {
		pairs[i] = pair{v, i}
	}
	sort.Slice(pairs, func(i, j int) bool {
		return pairs[i].val < pairs[j].val
	})

	ans := make([]int, n)
	rank := 0
	for i, p := range pairs {
		if i == 0 || p.val != pairs[i-1].val {
			rank++
		}
		ans[p.idx] = rank
	}
	return ans
}

// @lc code=end
