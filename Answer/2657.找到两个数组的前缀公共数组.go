/*
 * @lc app=leetcode.cn id=2657 lang=golang
 *
 * [2657] 找到两个数组的前缀公共数组
 */

// @lc code=start

func findThePrefixCommonArray(A []int, B []int) []int {
	n := len(A)
	ans := make([]int, n)
	count := make([]int, n+1)
	common := 0
	for i := 0; i < n; i++ {
		count[A[i]]++
		if count[A[i]] == 2 {
			common++
		}

		count[B[i]]++
		if count[B[i]] == 2 {
			common++
		}

		ans[i] = common
	}
	return ans
}

// @lc code=end
