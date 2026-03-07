/*
 * @lc app=leetcode.cn id=1980 lang=golang
 *
 * [1980] 找出不同的二进制字符串
 */

// @lc code=start
func findDifferentBinaryString(nums []string) string {
	n := len(nums)
	res := make([]byte, n)
	for i := 0; i < n; i++ {
		if nums[i][i] == '0' {
			res[i] = '1'
		} else {
			res[i] = '0'
		}
	}
	return string(res)
}

// @lc code=end
