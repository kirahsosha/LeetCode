/*
 * @lc app=leetcode.cn id=1404 lang=golang
 *
 * [1404] 将二进制表示减到 1 的步骤数
 */

// @lc code=start
func numSteps(s string) int {
	step := 0
	carry := 0
	for i := len(s) - 1; i > 0; i-- {
		step++
		if int(s[i]-'0')+carry == 1 {
			carry = 1
			step++
		}
	}
	return step + carry
}

// @lc code=end
