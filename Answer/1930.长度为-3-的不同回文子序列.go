/*
 * @lc app=leetcode.cn id=1930 lang=golang
 *
 * [1930] 长度为 3 的不同回文子序列
 */

// @lc code=start
func countPalindromicSubsequence(s string) int {
    dic := make(map[rune][]int)
    res := make(map[string]bool)
	for i, c := range(s) {
		if _, exists := dic[c]; exists {
			dic[c] = append(dic[c], i)
		} else {
			dic[c] = []int{i}
		}
	}
	for k, v := range dic {
		if len(v) >= 2 {
			l := v[0]
			r := v[len(v)-1]
			for j := l + 1; j < r; j++ {
				p := string(k) + string(s[j]) + string(k)
				res[p] = true
			}
		}
	}

	return len(res)
}
// @lc code=end

