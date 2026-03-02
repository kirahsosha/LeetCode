/*
 * @lc app=leetcode.cn id=1536 lang=golang
 *
 * [1536] 排布二进制网格的最少交换次数
 */

// @lc code=start
func minSwaps(grid [][]int) int {
	n := len(grid)
	aim := make([]int, n)
	for i := 0; i < n; i++ {
		count := n - 1
		for j := n - 1; j >= 0; j-- {
			count = j
			if grid[i][j] == 1 {
				break
			}
		}
		aim[i] = count
	}
	ans := 0
	for i := 0; i < n; i++ {
		j := i
		for j < n && aim[j] > i {
			j++
		}
		if j == n {
			return -1
		}
		ans += j - i
		for k := j; k > i; k-- {
			aim[k] = aim[k-1]
		}
	}
	return ans
}

// @lc code=end
