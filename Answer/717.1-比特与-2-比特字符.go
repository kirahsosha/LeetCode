/*
 * @lc app=leetcode.cn id=717 lang=golang
 *
 * [717] 1 比特与 2 比特字符
 */

// @lc code=start
func isOneBitCharacter(bits []int) bool {
    if len(bits) == 1 {
		return true
	}
	n := len(bits)
	index := 0
	for index < n {
		if bits[index] == 1 {
			index += 2
			if index >= n {
				return false
			}
		} else {
			index += 1
			if index == n {
				return true
			}
		}
    }
	return true;
}

// @lc code=end

