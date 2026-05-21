/*
 * @lc app=leetcode.cn id=3043 lang=golang
 *
 * [3043] 最长公共前缀的长度
 */

// @lc code=start
func longestCommonPrefix(arr1 []int, arr2 []int) int {
	prefixSet := make(map[int]struct{})

	for _, num := range arr1 {
		for n := num; n > 0; n /= 10 {
			prefixSet[n] = struct{}{}
		}
	}

	maxLen := 0
	for _, num := range arr2 {
		length := 0
		for temp := num; temp > 0; temp /= 10 {
			length++
		}
		for n := num; n > 0; n /= 10 {
			if _, ok := prefixSet[n]; ok {
				if length > maxLen {
					maxLen = length
				}
				break
			}
			length--
		}
	}

	return maxLen
}
// @lc code=end
