/*
 * @lc app=leetcode.cn id=696 lang=golang
 *
 * [696] 计数二进制子串
 */

// @lc code=start
func countBinarySubstrings(s string) int {
    a := '0'
    count := 0
    old := 0
    res := 0
    for _, c := range s {
        if c == a {
            count += 1
        } else {
            res += min(old, count)
            old = count
            a = c
            count = 1
        }
    }
    res += min(old, count)
    return res
}
// @lc code=end

