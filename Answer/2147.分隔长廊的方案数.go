/*
 * @lc app=leetcode.cn id=2147 lang=golang
 *
 * [2147] 分隔长廊的方案数
 */

// @lc code=start
func numberOfWays(corridor string) int {
	MOD := 1000000007
	var seats []int
	for i := 0; i < len(corridor); i++ {
		if corridor[i] == 'S' {
			seats = append(seats, i)
		}
	}
	if len(seats) == 0 || len(seats)%2 == 1 {
		return 0
	}

	var res = 1
	var index = 0
	for i := 1; i < len(seats)-1; i++ {
		if index == 0 {
			index = seats[i]
		} else {
			res = (res * (seats[i] - index)) % MOD
			index = 0
		}
	}
	return res
}

// @lc code=end

