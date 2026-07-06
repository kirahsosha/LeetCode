/*
 * @lc app=leetcode.cn id=1288 lang=javascript
 *
 * [1288] 删除被覆盖区间
 */

// @lc code=start
/**
 * @param {number[][]} intervals
 * @return {number}
 */
var removeCoveredIntervals = function (intervals) {
    intervals.sort(function (a, b) {
        return a[0] - b[0] || b[1] - a[1];
    });

    var ans = 0;
    var end = 0;
    for (var i = 0; i < intervals.length; i++) {
        if (intervals[i][1] > end) {
            ans++;
            end = intervals[i][1];
        }
    }
    return ans;
};
// @lc code=end
