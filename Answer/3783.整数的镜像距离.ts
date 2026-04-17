/*
 * @lc app=leetcode.cn id=3783 lang=typescript
 *
 * [3783] 整数的镜像距离
 */

// @lc code=start
function mirrorDistance(n: number): number {
    let rev = 0;
    for (let x = n; x > 0; x = Math.floor(x / 10)) {
        rev = rev * 10 + x % 10;
    }
    return Math.abs(rev - n);
}
// @lc code=end
