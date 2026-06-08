/*
 * @lc app=leetcode.cn id=2161 lang=golang
 *
 * [2161] 根据给定数字划分数组
 */

// @lc code=start
func pivotArray(nums []int, pivot int) []int {
	n := len(nums)
	ans := make([]int, n)
	left, right := 0, n-1
	for _, num := range nums {
		if num < pivot {
			ans[left] = num
			left++
		} else if num > pivot {
			ans[right] = num
			right--
		}
	}
	for i := left; i <= right; i++ {
		ans[i] = pivot
	}
	for i, j := right+1, n-1; i < j; i, j = i+1, j-1 {
		ans[i], ans[j] = ans[j], ans[i]
	}
	return ans
}

// @lc code=end
