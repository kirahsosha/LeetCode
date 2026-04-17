/*
 * @lc app=leetcode.cn id=3761 lang=golang
 *
 * [3761] 镜像对之间最小绝对距离
 */

// @lc code=start
func minMirrorPairDistance(nums []int) int {
	n := len(nums)
	dic := make(map[int]int, n)
	res := n

	for j, num := range nums {
		if i, ok := dic[num]; ok {
			res = min(res, j-i)
		}
		rev := 0
		for x := num; x > 0; x /= 10 {
			rev = rev*10 + x%10
		}
		dic[rev] = j
	}
	if res == n {
		return -1
	}
	return res
}

// @lc code=end
