/*
 * @lc app=leetcode.cn id=3488 lang=typescript
 *
 * [3488] 距离最小相等元素查询
 */

// @lc code=start
function solveQueries(nums: number[], queries: number[]): number[] {
    const n = nums.length;
    const left = new Int32Array(n);
    const right = new Int32Array(n);
    const first = new Map<number, number>();
    const last = new Map<number, number>();

    for (let i = 0; i < n; i++) {
        const x = nums[i];
        if (last.has(x)) {
            const j = last.get(x)!;
            left[i] = j;
            right[j] = i;
        } else {
            left[i] = -1;
        }
        if (!first.has(x)) {
            first.set(x, i);
        }
        last.set(x, i);
    }

    for (let qi = 0; qi < queries.length; qi++) {
        const i = queries[qi];
        let l = left[i];
        if (l < 0) {
            l = last.get(nums[i])! - n;
        }
        if (i - l === n) {
            queries[qi] = -1;
        } else {
            let r = right[i];
            if (r === 0) {
                r = first.get(nums[i])! + n;
            }
            queries[qi] = Math.min(i - l, r - i);
        }
    }
    return queries;
};
// @lc code=end
