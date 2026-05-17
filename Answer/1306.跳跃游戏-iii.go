/*
 * @lc app=leetcode.cn id=1306 lang=golang
 *
 * [1306] 跳跃游戏 III
 */

// @lc code=start
func canReach(arr []int, start int) bool {
    n := len(arr)
	visited := make([]bool, n)
	stack := []int{start}
	visited[start] = true
	for len(stack) > 0 {
		i := stack[len(stack)-1]
		stack = stack[:len(stack)-1]
		if arr[i] == 0 {
			return true
		}
		next := i + arr[i]
		if next < n && !visited[next] {
			visited[next] = true
			stack = append(stack, next)
		}
		prev := i - arr[i]
		if prev >= 0 && !visited[prev] {
			visited[prev] = true
			stack = append(stack, prev)
		}
	}
	return false
}
// @lc code=end

