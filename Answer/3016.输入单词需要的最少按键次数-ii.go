/*
 * @lc app=leetcode.cn id=3016 lang=golang
 *
 * [3016] 输入单词需要的最少按键次数 II
 */

// @lc code=start
func minimumPushes(word string) int {
	var cnt [26]int
	for i := 0; i < len(word); i++ {
		cnt[word[i]-'a']++
	}
	sort.Slice(cnt[:], func(i, j int) bool {
		return cnt[i] > cnt[j]
	})
	ans := 0
	for i := 0; i < 26 && cnt[i] > 0; i++ {
		ans += (i/8 + 1) * cnt[i]
	}
	return ans
}

// @lc code=end
