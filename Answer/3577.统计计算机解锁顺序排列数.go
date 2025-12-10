/*
 * @lc app=leetcode.cn id=3577 lang=golang
 *
 * [3577] 统计计算机解锁顺序排列数
 */

// @lc code=start
func countPermutations(complexity []int) int {
	MOD := int64(1000000007)
	res := int64(1)
	for i, v := range complexity {
		if i == 0 {
			continue
		}
		if v <= complexity[0] {
			return 0
		}
		res = res * int64(i) % MOD
	}
	return int(res)
}

// @lc code=end

