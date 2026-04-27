import "sort"

/*
 * @lc app=leetcode.cn id=2033 lang=golang
 *
 * [2033] 获取单值网格的最小操作数
 */

// @lc code=start
func minOperations(grid [][]int, x int) int {
	m, n := len(grid), len(grid[0])
	base := grid[0][0]
	nums := make([]int, 0, m*n)

	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			num := grid[i][j]
			if (num-base)%x != 0 {
				return -1
			}
			nums = append(nums, num)
		}
	}

	sort.Ints(nums)
	median := nums[len(nums)/2]

	ans := 0
	for _, num := range nums {
		if num > median {
			ans += (num - median) / x
		} else {
			ans += (median - num) / x
		}
	}
	return ans
}

// @lc code=end
