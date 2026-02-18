/*
 * @lc app=leetcode.cn id=693 lang=golang
 *
 * [693] 交替位二进制数
 */

// @lc code=start
func hasAlternatingBits(n int) bool {
    a := n ^ (n >> 1)
    b := a + 1
    return (a & b) == 0
}
// @lc code=end

