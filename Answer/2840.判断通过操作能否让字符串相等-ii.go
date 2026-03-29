/*
 * @lc app=leetcode.cn id=2840 lang=golang
 *
 * [2840] 判断通过操作能否让字符串相等 II
 */

// @lc code=start
func checkStrings(s1 string, s2 string) bool {
	cnt1, cnt2 := [2][26]int{}, [2][26]int{}
	for i := 0; i < len(s1); i++ {
		cnt1[i%2][s1[i]-'a']++
		cnt2[i%2][s2[i]-'a']++
	}
	return cnt1 == cnt2
}

// @lc code=end
