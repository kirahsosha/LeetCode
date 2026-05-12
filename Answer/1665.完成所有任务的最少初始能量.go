/*
 * @lc app=leetcode.cn id=1665 lang=golang
 *
 * [1665] 完成所有任务的最少初始能量
 */

// @lc code=start
func minimumEffort(tasks [][]int) int {
	slices.SortFunc(tasks, func(a, b []int) int {
		// 按照 minimum - actual 从小到大排序
		return (a[1] - a[0]) - (b[1] - b[0])
	})

    ans := 0

	for _, task := range tasks {
		minimum, actualCost := task[1], task[0]
		ans += actualCost
		if ans < minimum {
			ans = minimum
		}
	}
	return ans
}
// @lc code=end

