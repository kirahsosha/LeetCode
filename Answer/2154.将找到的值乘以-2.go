/*
 * @lc app=leetcode.cn id=2154 lang=golang
 *
 * [2154] 将找到的值乘以 2
 */

// @lc code=start
func findFinalValue(nums []int, original int) int {
    m := make(map[int]bool)
	for _, k := range nums {
		m[k] = true;
	}
	for ;; {
		if m[original] {
			original *= 2
		} else {
			break
		}
	}
	return original
}
// @lc code=end

