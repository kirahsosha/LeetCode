/*
 * @lc app=leetcode.cn id=2515 lang=golang
 *
 * [2515] 到目标字符串的最短距离
 */

// @lc code=start
func closestTarget(words []string, target string, startIndex int) int {
	ans := -1
	n := len(words)
	for i := 0; i < n/2+1; i++ {
		if words[(startIndex+i)%n] == target || words[(startIndex-i+n)%n] == target {
			ans = i
			break
		}
	}
	return ans
}

// @lc code=end
