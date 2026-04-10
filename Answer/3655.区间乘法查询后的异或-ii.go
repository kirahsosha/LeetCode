/*
 * @lc app=leetcode.cn id=3655 lang=golang
 *
 * [3655] 区间乘法查询后的异或 II
 */

// @lc code=start
const mod = 1000000007

func xorAfterQueries(nums []int, queries [][]int) int {
	n := len(nums)
	limit := 1
	for (limit+1)*(limit+1) <= len(queries) {
		limit++
	}
	if limit > n {
		limit = n
	}

	diff := make([][]int, limit+1)
	smallKs := make([]int, 0, limit)
	used := make([]bool, limit+1)

	for _, q := range queries {
		l, r, k, v := q[0], q[1], q[2], q[3]
		if k <= limit {
			if !used[k] {
				used[k] = true
				smallKs = append(smallKs, k)
				diff[k] = make([]int, n)
				for i := range diff[k] {
					diff[k][i] = 1
				}
			}
			diff[k][l] = mulMod(diff[k][l], v)
			end := l + (r-l)/k*k + k
			if end < n {
				diff[k][end] = mulMod(diff[k][end], modInverse(v))
			}
			continue
		}

		for i := l; i <= r; i += k {
			nums[i] = mulMod(nums[i], v)
		}
	}

	for _, k := range smallKs {
		for i := 0; i < n; i++ {
			if i >= k {
				diff[k][i] = mulMod(diff[k][i], diff[k][i-k])
			}
			nums[i] = mulMod(nums[i], diff[k][i])
		}
	}

	res := 0
	for _, num := range nums {
		res ^= num
	}
	return res
}

func mulMod(a, b int) int {
	return int(int64(a) * int64(b) % mod)
}

func modInverse(value int) int {
	return modPow(value, mod-2)
}

func modPow(base, exp int) int {
	result := 1
	for exp > 0 {
		if exp&1 == 1 {
			result = mulMod(result, base)
		}
		base = mulMod(base, base)
		exp >>= 1
	}
	return result
}

// @lc code=end
