/*
 * @lc app=leetcode.cn id=1871 lang=golang
 *
 * [1871] 跳跃游戏 VII
 */

// @lc code=start
func canReach(s string, minJump int, maxJump int) bool {
	n := len(s)
	sum := make([]int, n+1)
	sum[1] = 1
	for j := 1; j < n; j++ {
		sum[j+1] = sum[j]
		if j >= minJump && s[j] == '0' && sum[j-minJump+1] > sum[max(j-maxJump, 0)] {
			sum[j+1]++
		}
	}
	return sum[n] > sum[n-1]
}

// @lc code=end
