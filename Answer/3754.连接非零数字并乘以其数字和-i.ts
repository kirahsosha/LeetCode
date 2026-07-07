/*
 * @lc app=leetcode.cn id=3754 lang=typescript
 *
 * [3754] 连接非零数字并乘以其数字和 I
 */

// @lc code=start
function sumAndMultiply(n: number): number {
    let x = 0;
    let pow = 1;
    let sum = 0;
    while (n > 0) {
        const d = n % 10;
        if (d !== 0) {
            x += d * pow;
            pow *= 10;
            sum += d;
        }
        n = Math.floor(n / 10);
    }
    return x * sum;
}
// @lc code=end
