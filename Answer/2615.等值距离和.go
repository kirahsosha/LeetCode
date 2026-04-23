/*
 * @lc app=leetcode.cn id=2615 lang=golang
 *
 * [2615] 等值距离和
 */

// @lc code=start
func distance(nums []int) []int64 {
	n := len(nums)
	ans := make([]int64, n)

	// 从左向右：计算每个位置左侧同值元素的距离和
	cnt := make(map[int]int, n)
	sum := make(map[int]int64, n)
	for i, num := range nums {
		c := cnt[num]
		s := sum[num]
		idx := int64(i)
		ans[i] = idx*int64(c) - s
		cnt[num] = c + 1
		sum[num] = s + idx
	}

	// 从右向左：计算每个位置右侧同值元素的距离和并累加
	cnt = make(map[int]int, n)
	sum = make(map[int]int64, n)
	for i := n - 1; i >= 0; i-- {
		num := nums[i]
		c := cnt[num]
		s := sum[num]
		idx := int64(i)
		ans[i] += s - idx*int64(c)
		cnt[num] = c + 1
		sum[num] = s + idx
	}

	return ans
}

// @lc code=end
