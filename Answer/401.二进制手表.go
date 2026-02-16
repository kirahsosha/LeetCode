/*
 * @lc app=leetcode.cn id=401 lang=golang
 *
 * [401] 二进制手表
 */

// @lc code=start
func readBinaryWatch(turnedOn int) []string {
    var combineNumber func(number int, digit int, last int) []int
	combineNumber = func(number int, digit int, last int) []int {
		if last == 0 {
			return []int{number}
		} else if digit == last {
			return combineNumber((number<<1)+1, digit-1, last-1)
		} else if digit == 0 {
			return combineNumber(number<<1, digit, last-1)
		} else {
			res := make([]int, 0)
			res = append(res, combineNumber((number<<1)+1, digit-1, last-1)...)
			res = append(res, combineNumber(number<<1, digit, last-1)...)
			return res
		}
	}
	res := make([]string, 0)
	for _, num := range combineNumber(0, turnedOn, 10) {
		minute := num >> 4
		hour := num & 0x0000000f
		if hour >= 12 || minute >= 60 {
			continue
		}
		res = append(res, fmt.Sprintf("%d:%02d", hour, minute))
	}
	return res
}
// @lc code=end

