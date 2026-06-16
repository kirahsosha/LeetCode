/*
 * @lc app=leetcode.cn id=3612 lang=golang
 *
 * [3612] 用特殊操作处理字符串 I
 */

// @lc code=start
func processStr(s string) string {
	ans := make([]byte, 0, 1024)
	for i := 0; i < len(s); i++ {
		ch := s[i]
		switch ch {
		case '*':
			if len(ans) > 0 {
				ans = ans[:len(ans)-1]
			}
		case '#':
			ans = append(ans, ans...)
		case '%':
			for l, r := 0, len(ans)-1; l < r; l, r = l+1, r-1 {
				ans[l], ans[r] = ans[r], ans[l]
			}
		default:
			ans = append(ans, ch)
		}
	}
	return string(ans)
}

// @lc code=end
