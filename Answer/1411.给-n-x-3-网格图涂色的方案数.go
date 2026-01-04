/*
 * @lc app=leetcode.cn id=1411 lang=golang
 *
 * [1411] 给 N x 3 网格图涂色的方案数
 */

// @lc code=start
func numOfWays(n int) int {
	//i - row - 0 ~ n-1
	//j - type - 0 ~ 11
	//dp[0][k] = 1
	//0 - 010 - 4 5 6 8 9
	//1 - 012 - 4 6 7 9
	//2 - 020 - 4 5 8 9 10
	//3 - 021 - 5 8 10 11
	//4 - 101 - 0 1 2 10 11
	//5 - 102 - 0 2 3 11
	//6 - 121 - 0 1 8 10 11
	//7 - 120 - 1 8 9 10
	//8 - 202 - 0 2 3 6 7
	//9 - 201 - 0 1 2 7
	//10 - 212 - 2 3 4 6 7
	//11 - 210 - 3 4 5 6
	MOD := 1000000007
	res := []int{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
	line := make([]int, 12)
	for i := 1; i < n; i++ {
		line[0] = ((((res[4]+res[5])%MOD+res[6])%MOD+res[8])%MOD + res[9]) % MOD
		line[1] = (((res[4]+res[6])%MOD+res[7])%MOD + res[9]) % MOD
		line[2] = ((((res[4]+res[5])%MOD+res[8])%MOD+res[9])%MOD + res[10]) % MOD
		line[3] = (((res[5]+res[8])%MOD+res[10])%MOD + res[11]) % MOD
		line[4] = ((((res[0]+res[1])%MOD+res[2])%MOD+res[10])%MOD + res[11]) % MOD
		line[5] = (((res[0]+res[2])%MOD+res[3])%MOD + res[11]) % MOD
		line[6] = ((((res[0]+res[1])%MOD+res[8])%MOD+res[10])%MOD + res[11]) % MOD
		line[7] = (((res[1]+res[8])%MOD+res[9])%MOD + res[10]) % MOD
		line[8] = ((((res[0]+res[2])%MOD+res[3])%MOD+res[6])%MOD + res[7]) % MOD
		line[9] = (((res[0]+res[1])%MOD+res[2])%MOD + res[7]) % MOD
		line[10] = ((((res[2]+res[3])%MOD+res[4])%MOD+res[6])%MOD + res[7]) % MOD
		line[11] = (((res[3]+res[4])%MOD+res[5])%MOD + res[6]) % MOD
		res = line
		line = make([]int, 12)
	}
	ans := 0
	for i := range 12 {
		ans = (ans + res[i]) % MOD
	}
	return ans
}

// @lc code=end
