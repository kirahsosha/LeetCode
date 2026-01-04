/*
 * @lc app=leetcode.cn id=961 lang=golang
 *
 * [961] 在长度 2N 的数组中找出重复 N 次的元素
 */

// @lc code=start
func repeatedNTimes(nums []int) int {
	res := 0
	ans := make(map[int]bool)
	for _, n := range nums {
		if ans[n] {
			res = n
			break
		}
		ans[n] = true
	}
	return res
}

// @lc code=end
