/*
 * @lc app=leetcode.cn id=3488 lang=golang
 *
 * [3488] 距离最小相等元素查询
 */

// @lc code=start
func solveQueries(nums []int, queries []int) []int {
	n := len(nums)
	left := make([]int, n)
	right := make([]int, n)
	first := map[int]int{} // 首次出现的位置
	last := map[int]int{}  // 最后一次出现的位置
	for i, x := range nums {
		j, ok := last[nums[i]]
		if ok {
			left[i] = j
			right[j] = i
		} else {
			left[i] = -1
		}
		if _, ok := first[x]; !ok {
			first[x] = i
		}
		last[x] = i
	}

	for qi, i := range queries {
		l := left[i]
		if l < 0 {
			l = last[nums[i]] - n
		}
		if i-l == n {
			queries[qi] = -1
		} else {
			r := right[i]
			if r == 0 {
				r = first[nums[i]] + n
			}
			queries[qi] = min(i-l, r-i)
		}
	}
	return queries
}

// @lc code=end
