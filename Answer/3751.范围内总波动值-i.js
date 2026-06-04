/*
 * @lc app=leetcode.cn id=3751 lang=javascript
 *
 * [3751] 范围内总波动值 I
 */

// @lc code=start
/**
 * @param {number} num1
 * @param {number} num2
 * @return {number}
 */
var totalWaviness = function (num1, num2) {
    if (num1 <= 0) {
        return prefix[num2];
    }
    return prefix[num2] - prefix[num1 - 1];
};

const maxN = 100000;
const waviness = new Array(maxN + 1).fill(0);
for (let x = 100; x <= maxN; x++) {
    const s = x.toString();
    let cnt = 0;
    for (let j = 1; j < s.length - 1; j++) {
        if ((s[j] > s[j - 1] && s[j] > s[j + 1]) ||
            (s[j] < s[j - 1] && s[j] < s[j + 1])) {
            cnt++;
        }
    }
    waviness[x] = cnt;
}
const prefix = new Array(maxN + 1).fill(0);
for (let i = 1; i <= maxN; i++) {
    prefix[i] = prefix[i - 1] + waviness[i];
}
// @lc code=end
