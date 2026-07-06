/*
 * @lc app=leetcode.cn id=1288 lang=typescript
 *
 * [1288] 删除被覆盖区间
 */

// @lc code=start
function removeCoveredIntervals(intervals: number[][]): number {
    intervals.sort((a, b) => a[0] - b[0] || b[1] - a[1]);

    let ans = 0;
    let end = 0;
    for (const it of intervals) {
        if (it[1] > end) {
            ans++;
            end = it[1];
        }
    }
    return ans;
}
// @lc code=end
