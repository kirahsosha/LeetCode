/*
 * @lc app=leetcode.cn id=1784 lang=typescript
 *
 * [1784] 检查二进制字符串字段
 */

// @lc code=start
function checkOnesSegment(s: string): boolean {
    var res = false;
    var hasZero = false;
    for (var i = 0; i < s.length; i++) {
        if (s.charAt(i) == '1' && !res) {
            res = true;
        } else if (s.charAt(i) == '0' && res) {
            hasZero = true;
        } else if (s.charAt(i) == '1' && hasZero) {
            return false;
        }
    }
    return res;
};
// @lc code=end

