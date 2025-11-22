/*
 * @lc app=leetcode.cn id=3190 lang=golang
 *
 * [3190] 使所有元素都可以被 3 整除的最少操作数
 */

// @lc code=start
func minimumOperations(nums []int) int {
    res := 0
	for _, n := range nums {
		if n % 3 != 0 {
			res++
		}
	}
	return res
}
// @lc code=end

