/*
 * @lc app=leetcode.cn id=2452 lang=golang
 *
 * [2452] 距离字典两次编辑以内的单词
 */

// @lc code=start
func twoEditWords(queries []string, dictionary []string) []string {
	editTimes := func(a, b string) int {
		time := 0
		for i, c := range a {
			if c != rune(b[i]) {
				time++
			}
		}
		return time
	}

	if len(dictionary) == 0 || len(queries) == 0 {
		return []string{}
	}

	ans := []string{}
	for _, query := range queries {
		for _, dict := range dictionary {
			if editTimes(query, dict) <= 2 {
				ans = append(ans, query)
				break
			}
		}
	}
	return ans
}

// @lc code=end
