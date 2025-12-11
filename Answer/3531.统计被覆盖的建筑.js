/*
 * @lc app=leetcode.cn id=3531 lang=javascript
 *
 * [3531] 统计被覆盖的建筑
 */

// @lc code=start
/**
 * @param {number} n
 * @param {number[][]} buildings
 * @return {number}
 */
var countCoveredBuildings = function (n, buildings) {
    //Key：横坐标；Value：纵坐标范围
    let ver = new Map();
    //Key：纵坐标；Value：横坐标范围
    let hor = new Map();
    buildings.forEach(building => {
        let x = building[0];
        let y = building[1];
        if (ver.has(x)) {
            ver.get(x)[0] = Math.min(ver.get(x)[0], y);
            ver.get(x)[1] = Math.max(ver.get(x)[1], y);
        } else {
            ver.set(x, [y, y]);
        }
        if (hor.has(y)) {
            hor.get(y)[0] = Math.min(hor.get(y)[0], x);
            hor.get(y)[1] = Math.max(hor.get(y)[1], x);
        } else {
            hor.set(y, [x, x]);
        }
    });
    let res = 0;
    buildings.forEach(building => {
        var x = building[0];
        var y = building[1];
        if (ver.get(x)[0] < y && ver.get(x)[1] > y && hor.get(y)[0] < x && hor.get(y)[1] > x) {
            res++;
        }
    });
    return res;
};
// @lc code=end

