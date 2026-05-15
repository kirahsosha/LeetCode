/*
 * @lc app=leetcode.cn id=2784 lang=golang
 *
 * [2784] 检查数组是否是好的
 */

// @lc code=start
func isGood(nums []int) bool {
	n := len(nums) - 1
    res := make([]int, n)
	if n == 0 {
		return false
	}
	for _, num := range nums {
		if num > n || num <= 0 {
			return false
		}
		if num != n && res[num-1] == 1 {
			return false
		}
		if num == n && res[num-1] > 1 {
			return false
		}
		res[num-1]++
	}
	return true
}
// @lc code=end

