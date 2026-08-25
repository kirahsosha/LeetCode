/*
 * @lc app=leetcode.cn id=3718 lang=golang
 *
 * [3718] 缺失的最小倍数
 */

// @lc code=start
func missingMultiple(nums []int, k int) int {
	set := make(map[int]struct{}, len(nums))
	for _, v := range nums {
		set[v] = struct{}{}
	}
	multiple := k
	for {
		if _, ok := set[multiple]; !ok {
			return multiple
		}
		multiple += k
	}
}
// @lc code=end
