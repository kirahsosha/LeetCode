/*
 * @lc app=leetcode.cn id=1848 lang=golang
 *
 * [1848] 到目标元素的最小距离
 */

// @lc code=start
func getMinDistance(nums []int, target int, start int) int {
	n := len(nums)
	ans := -1
	for i := 0; i < n; i++ {
		if start+i < n && nums[start+i] == target {
			ans = i
			break
		}
		if start-i >= 0 && nums[start-i] == target {
			ans = i
			break
		}
		if start+i >= n && start-i < 0 {
			break
		}
	}
	return ans
}

// @lc code=end
