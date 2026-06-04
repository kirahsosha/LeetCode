import "strconv"

/*
 * @lc app=leetcode.cn id=3751 lang=golang
 *
 * [3751] 范围内总波动值 I
 */

// @lc code=start

var prefix []int

func init() {
	const maxN = 100000
	waviness := make([]int, maxN+1)
	for x := 100; x <= maxN; x++ {
		s := strconv.Itoa(x)
		cnt := 0
		for j := 1; j < len(s)-1; j++ {
			if (s[j] > s[j-1] && s[j] > s[j+1]) || (s[j] < s[j-1] && s[j] < s[j+1]) {
				cnt++
			}
		}
		waviness[x] = cnt
	}
	prefix = make([]int, maxN+1)
	for i := 1; i <= maxN; i++ {
		prefix[i] = prefix[i-1] + waviness[i]
	}
}

func totalWaviness(num1 int, num2 int) int {
	if num1 <= 0 {
		return prefix[num2]
	}
	return prefix[num2] - prefix[num1-1]
}

// @lc code=end
