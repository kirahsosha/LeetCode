/*
 * @lc app=leetcode.cn id=3512 lang=golang
 *
 * [3512] 使数组和能被 K 整除的最少操作次数
 */

// @lc code=start
func minOperations(nums []int, k int) int {
    res := 0
	for _, n := range nums {
		res = (res + n) % k
	}
	return res
}
// @lc code=end

