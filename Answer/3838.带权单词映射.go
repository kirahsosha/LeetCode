import "strings"

/*
 * @lc app=leetcode.cn id=3838 lang=golang
 *
 * [3838] 带权单词映射
 */

// @lc code=start
func mapWordWeights(words []string, weights []int) string {
	var sb strings.Builder
	sb.Grow(len(words))
	for _, word := range words {
		w := 0
		for i := 0; i < len(word); i++ {
			w = (w + weights[word[i]-'a']) % 26
		}
		sb.WriteByte('a' + byte(25-w))
	}
	return sb.String()
}

// @lc code=end
