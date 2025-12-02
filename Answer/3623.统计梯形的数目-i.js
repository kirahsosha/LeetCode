/*
 * @lc app=leetcode.cn id=3623 lang=javascript
 *
 * [3623] 统计梯形的数目 I
 */

// @lc code=start
/**
 * @param {number[][]} points
 * @return {number}
 */
var countTrapezoids = function (points) {
    const MOD = 1000000007n;
    //key：纵坐标；value：线段数量
    var dic = new Map();
    points.forEach(point => {
        var y = point[1];
        if (dic.has(y)) {
            dic.set(y, dic.get(y) + 1);
        }
        else {
            dic.set(y, 1);
        }
    });
    var res = 0n;
    var side = 0n;
    dic.values().forEach(point => {
        var edge = BigInt(point) * BigInt(point - 1) / 2n;
        res = (res + edge * side) % MOD;
        side = (side + edge) % MOD;
    });
    return Number(res);
};
// @lc code=end

