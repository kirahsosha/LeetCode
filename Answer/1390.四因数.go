import "math"

/*
 * @lc app=leetcode.cn id=1390 lang=golang
 *
 * [1390] 四因数
 */

// @lc code=start
func sumFourDivisors(nums []int) int {
	res := 0
	for _, n := range nums {
		di := AllDivisors(n)
		if len(di) == 4 {
			for i, _ := range di {
				res += i
			}
		}
	}
	return res
}

func AllDivisors(n int) map[int]bool {
	res := make(map[int]bool)
	for i := 1; i <= int(math.Floor(math.Sqrt(float64(n))))+1; i++ {
		if n%i == 0 {
			res[i] = true
			res[n/i] = true
		}
	}
	return res
}

// @lc code=end
