/*
 * @lc app=leetcode.cn id=66 lang=javascript
 *
 * [66] 加一
 */

// @lc code=start
/**
 * @param {number[]} digits
 * @return {number[]}
 */
var plusOne = function (digits) {
    let n = digits.length;
    if (n == 1 && digits[0] == 0) {
        digits[0] = 1;
        return digits;
    }
    let t = 1;
    for (let i = n - 1; i >= 0; i--) {
        digits[i] += t;
        t = 0;
        if (digits[i] == 10) {
            digits[i] = 0;
            t = 1;
        }
        if (t == 0) {
            break;
        }
    }
    if (t == 1) {
        let a = [n + 1];
        a[0] = 1;
        for (let i = 0; i < n; i++) {
            a[i + 1] = digits[i];
        }
        return a;
    } else {
        return digits;
    }
};
// @lc code=end

