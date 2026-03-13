/*
 * @lc app=leetcode.cn id=1415 lang=golang
 *
 * [1415] 长度为 n 的开心字符串中字典序第 k 小的字符串
 */

// @lc code=start
func getHappyString(n int, k int) string {
	chars := []byte{'a', 'b', 'c'}
	res := make([]byte, 0, n)
	if k > 3*(1<<(n-1)) {
		return ""
	}
	for i := 0; i < n; i++ {
		count := 1 << (n - i - 1)
		for _, c := range chars {
			if len(res) > 0 && res[len(res)-1] == c {
				continue
			}
			if k <= count {
				res = append(res, c)
				break
			}
			k -= count
		}
	}
	return string(res)
}

// @lc code=end
