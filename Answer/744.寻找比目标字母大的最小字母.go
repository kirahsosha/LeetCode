/*
 * @lc app=leetcode.cn id=744 lang=golang
 *
 * [744] 寻找比目标字母大的最小字母
 */

// @lc code=start
func nextGreatestLetter(letters []byte, target byte) byte {
	index := 0
	for i, c := range letters {
		if c > target {
			index = i
			break
		}
	}
	return letters[index]
}

// @lc code=end
