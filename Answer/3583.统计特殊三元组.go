/*
 * @lc app=leetcode.cn id=3583 lang=golang
 *
 * [3583] 统计特殊三元组
 */

// @lc code=start
func specialTriplets(nums []int) int {
	MOD := 1000000007
	//记录每个值的出现次数
	dic := make(map[int]int)
	//记录i左边有多少符合条件nums[i]*2的值
	count := make(map[int]int)
	for i, v := range nums {
		dic[v]++
		if v != 0 && dic[v*2] != 0 {
			count[i] = dic[v*2]
		}
	}
	res := 0
	for key, value := range count {
		if key != 0 {
			right := dic[nums[key]*2] - value
			res = (value*right + res) % MOD
		}
	}
	//处理0
	if dic[0] >= 3 {
		zero := int64(0)
		zero = int64(dic[0]) * int64(dic[0]-1) * int64(dic[0]-2) / int64(6) % int64(MOD)
		res = (res + int(zero)) % MOD
	}
	return res
}

// @lc code=end

