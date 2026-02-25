/*
 * @lc app=leetcode.cn id=1404 lang=typescript
 *
 * [1404] 将二进制表示减到 1 的步骤数
 */

// @lc code=start
function numSteps(s: string): number {
    let step = 0;
    let carry = 0;
    for (let i = s.length - 1; i > 0; i--) {
        step++;
        if (parseInt(s[i]) + carry == 1) {
            carry = 1;
            step++;
        }
    }
    return step + carry;
};
// @lc code=end

