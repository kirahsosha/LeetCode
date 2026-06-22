/*
 * @lc app=leetcode.cn id=1189 lang=golang
 *
 * [1189] “气球” 的最大数量
 */

// @lc code=start
func maxNumberOfBalloons(text string) int {
	var cnt [26]int
	for i := 0; i < len(text); i++ {
		cnt[text[i]-'a']++
	}
	b := cnt['b'-'a']
	a := cnt['a'-'a']
	l := cnt['l'-'a'] / 2
	o := cnt['o'-'a'] / 2
	n := cnt['n'-'a']
	if a < b {
		b = a
	}
	if l < b {
		b = l
	}
	if o < b {
		b = o
	}
	if n < b {
		b = n
	}
	return b
}

// @lc code=end
