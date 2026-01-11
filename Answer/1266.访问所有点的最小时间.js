/*
 * @lc app=leetcode.cn id=1266 lang=javascript
 *
 * [1266] 访问所有点的最小时间
 */

// @lc code=start
/**
 * @param {number[][]} points
 * @return {number}
 */
var minTimeToVisitAllPoints = function (points) {
    var n = points.length;
    if (n == 1) {
        return 0;
    }
    var res = 0;
    var x1 = points[0][0];
    var y1 = points[0][1];
    for (var i = 1; i < n; i++) {
        var x = points[i][0];
        var y = points[i][1];
        res += Math.max(Math.abs(x - x1), Math.abs(y - y1));
        x1 = x;
        y1 = y;
    }
    return res;
};
// @lc code=end

