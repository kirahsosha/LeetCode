/*
 * @lc app=leetcode.cn id=1404 lang=javascript
 *
 * [1404] 将二进制表示减到 1 的步骤数
 */

// @lc code=start
/**
 * @param {string} s
 * @return {number}
 */
var numSteps = function (s) {
    let step = 0;
    let carry = 0;
    for (let i = s.length - 1; i > 0; i--) {
        step++;
        if (s.charAt(i) - '0' + carry == 1) {
            carry = 1;
            step++;
        }
    }
    return step + carry;
};
// @lc code=end

