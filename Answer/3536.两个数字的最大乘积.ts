/*
 * @lc app=leetcode.cn id=3536 lang=typescript
 *
 * [3536] 两个数字的最大乘积
 */

// @lc code=start
function maxProduct(n: number): number {
    let digit = 0;
    let ans = 0;
    while (n > 0) {
        const d = n % 10;
        ans = Math.max(ans, d * digit);
        digit = Math.max(digit, d);
        n = Math.floor(n / 10);
    }
    return ans;
}
// @lc code=end
