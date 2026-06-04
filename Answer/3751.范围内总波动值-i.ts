/*
 * @lc app=leetcode.cn id=3751 lang=typescript
 *
 * [3751] 范围内总波动值 I
 */

// @lc code=start
function totalWaviness(num1: number, num2: number): number {
    if (num1 <= 0) {
        return prefix[num2];
    }
    return prefix[num2] - prefix[num1 - 1];
}

const maxN = 100000;
const waviness: number[] = new Array(maxN + 1).fill(0);
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
const prefix: number[] = new Array(maxN + 1).fill(0);
for (let i = 1; i <= maxN; i++) {
    prefix[i] = prefix[i - 1] + waviness[i];
}
// @lc code=end
