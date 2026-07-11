/*
 * @lc app=leetcode.cn id=1331 lang=typescript
 *
 * [1331] 数组序号转换
 */

// @lc code=start
function arrayRankTransform(arr: number[]): number[] {
    const sorted = arr.slice().sort((a, b) => a - b);
    const rank = new Map<number, number>();
    let r = 1;
    for (const num of sorted) {
        if (!rank.has(num)) {
            rank.set(num, r++);
        }
    }
    return arr.map(x => rank.get(x)!);
}
// @lc code=end
