/*
 * @lc app=leetcode.cn id=2211 lang=javascript
 *
 * [2211] 统计道路上的碰撞次数
 */

// @lc code=start
/**
 * @param {string} directions
 * @return {number}
 */
var countCollisions = function (directions) {
    //L：state < 0，忽略；state >= 0，更新res += state + 1，state = 0
    //S：state < 0，更新state = 0；state >= 0，更新res += state，state = 0
    //R：state <= 0，更新state = 1；state > 0，更新state += 1
    var state = -1;
    var res = 0;
    for (var i = 0; i < directions.length; i++) {
        switch (directions[i]) {
            case 'L':
                if (state >= 0) {
                    res += state + 1;
                    state = 0;
                }
                break;
            case 'S':
                if (state < 0) {
                    state = 0;
                }
                else {
                    res += state;
                    state = 0;
                }
                break;

            case 'R':
                if (state <= 0) {
                    state = 1;
                }
                else {
                    state += 1;
                }
                break;
            default:
                break;
        }
    }
    return res;
};
// @lc code=end

