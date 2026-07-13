/*
 * @lc app=leetcode.cn id=1291 lang=golang
 *
 * [1291] 顺次数
 */

// @lc code=start
func sequentialDigits(low int, high int) []int {
	res := make([]int, 0, 36)
	delta := 1
	offset := 0
	for length := 2; length <= 9; length++ {
		delta = delta*10 + 1
		offset = offset*10 + (length - 1)

		minNum := delta + offset
		if minNum > high {
			break
		}
		maxNum := (10-length)*delta + offset
		if maxNum < low {
			continue
		}
		for start := 1; start <= 10-length; start++ {
			num := start*delta + offset
			if num < low {
				continue
			}
			if num > high {
				break
			}
			res = append(res, num)
		}
	}
	return res
}

// @lc code=end
