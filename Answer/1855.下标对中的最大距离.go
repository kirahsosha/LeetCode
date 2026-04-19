/*
 * @lc app=leetcode.cn id=1855 lang=golang
 *
 * [1855] 下标对中的最大距离
 */

// @lc code=start
func maxDistance(nums1, nums2 []int) (ans int) {
	i := 0
	for j, y := range nums2 {
		for i < len(nums1) && nums1[i] > y {
			i++
		}
		if i == len(nums1) {
			break
		}
		ans = max(ans, j-i)
	}
	return
}

// @lc code=end
