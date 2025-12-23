import "sort"

/*
 * @lc app=leetcode.cn id=3074 lang=golang
 *
 * [3074] 重新分装苹果
 */

// @lc code=start
func minimumBoxes(apple []int, capacity []int) int {
	apples := 0
	for _, appleCount := range apple {
		apples += appleCount
	}
	sort.Slice(capacity, func(i, j int) bool {
		return capacity[i] > capacity[j]
	})
	res := 0
	for _, cap := range capacity {
		apples -= cap
		res += 1
		if apples <= 0 {
			break
		}
	}
	return res
}

// @lc code=end
