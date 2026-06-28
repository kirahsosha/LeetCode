/*
 * @lc app=leetcode.cn id=1846 lang=typescript
 *
 * [1846] 减小和重新排列数组后的最大元素
 */

// @lc code=start
function maximumElementAfterDecrementingAndRearranging(arr: number[]): number {
    arr.sort((a, b) => a - b);
    let prev = 0;
    for (const x of arr) {
        prev = Math.min(x, prev + 1);
    }
    return prev;
}
// @lc code=end
