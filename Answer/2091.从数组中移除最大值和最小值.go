/*
 * @lc app=leetcode.cn id=2091 lang=golang
 *
 * [2091] 从数组中移除最大值和最小值
 */

// @lc code=start
func minimumDeletions(nums []int) int {
	n := len(nums)
	minIndex, maxIndex := 0, 0
	for i := 1; i < n; i++ {
		if nums[i] < nums[minIndex] {
			minIndex = i
		}
		if nums[i] > nums[maxIndex] {
			maxIndex = i
		}
	}
	if minIndex > maxIndex {
		minIndex, maxIndex = maxIndex, minIndex
	}
	ans := maxIndex + 1
	if n-minIndex < ans {
		ans = n - minIndex
	}
	if minIndex+1+n-maxIndex < ans {
		ans = minIndex + 1 + n - maxIndex
	}
	return ans
}

// @lc code=end