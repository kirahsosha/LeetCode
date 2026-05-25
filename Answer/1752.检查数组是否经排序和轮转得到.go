/*
 * @lc app=leetcode.cn id=1752 lang=golang
 *
 * [1752] 检查数组是否经排序和轮转得到
 */

// @lc code=start
func check(nums []int) bool {
	cnt := 0
	n := len(nums)
	for i := 0; i < n; i++ {
		if nums[i] > nums[(i+1)%n] {
			cnt++
		}
	}
	return cnt <= 1
}

// @lc code=end
