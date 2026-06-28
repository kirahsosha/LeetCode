import "sort"

/*
 * @lc app=leetcode.cn id=1846 lang=golang
 *
 * [1846] 减小和重新排列数组后的最大元素
 */

// @lc code=start
func maximumElementAfterDecrementingAndRearranging(arr []int) int {
	sort.Ints(arr)
	prev := 0
	for _, x := range arr {
		if x > prev+1 {
			x = prev + 1
		}
		prev = x
	}
	return prev
}

// @lc code=end
