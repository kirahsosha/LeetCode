/*
 * @lc app=leetcode.cn id=2540 lang=golang
 *
 * [2540] 最小公共值
 */

// @lc code=start
func getCommon(nums1 []int, nums2 []int) int {
	left := 0
	right := 0
	n1 := len(nums1)
	n2 := len(nums2)

	for left < n1 && right < n2 {
		if nums1[left] == nums2[right] {
			return nums1[left]
		} else if nums1[left] < nums2[right] {
			left++
		} else {
			right++
		}
	}
	return -1
}

// @lc code=end
