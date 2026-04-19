/*
 * @lc app=leetcode.cn id=2078 lang=golang
 *
 * [2078] 两栋颜色不同且距离最远的房子
 */

// @lc code=start
func maxDistance(colors []int) int {
	n := len(colors)
	left := 0
	res := 0
	for left < n {
		if colors[left] != colors[n-1] {
			res = max(res, n-1-left)
			break
		}
		left++
	}
	if left == n {
		return res
	}
	right := n - 1
	for right >= 0 {
		if colors[0] != colors[right] {
			res = max(res, right)
			break
		}
		right--
	}
	return res
}

// @lc code=end
