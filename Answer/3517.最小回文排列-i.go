/*
 * @lc app=leetcode.cn id=3517 lang=golang
 *
 * [3517] 最小回文排列 I
 */

// @lc code=start
func smallestPalindrome(s string) string {
	n := len(s)
	cnt := [26]int{}
	for i := 0; i < n/2; i++ {
		cnt[s[i]-'a']++
	}
	ans := make([]byte, n)
	left, right := 0, n-1
	for i := 0; i < 26; i++ {
		c := byte('a' + i)
		for cnt[i] > 0 {
			ans[left] = c
			ans[right] = c
			left++
			right--
			cnt[i]--
		}
	}
	if n%2 == 1 {
		ans[left] = s[n/2]
	}
	return string(ans)
}

// @lc code=end
