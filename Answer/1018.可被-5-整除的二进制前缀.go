/*
 * @lc app=leetcode.cn id=1018 lang=golang
 *
 * [1018] 可被 5 整除的二进制前缀
 */

// @lc code=start
func prefixesDivBy5(nums []int) []bool {
    num := 0
	res := make([]bool, len(nums))
	for i, n := range nums {
		num = num * 2 + n
		if num % 5 == 0 {
			res[i] = true
		} else {
			res[i] = false
		}
		num = num % 10
	}
	return res
}
// @lc code=end

