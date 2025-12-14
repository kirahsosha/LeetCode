/*
 * @lc app=leetcode.cn id=2147 lang=javascript
 *
 * [2147] 分隔长廊的方案数
 */

// @lc code=start
/**
 * @param {string} corridor
 * @return {number}
 */
var numberOfWays = function (corridor) {
    const MOD = 1000000007;
    let list = Array();
    for (let i = 0; i < corridor.length; i++) {
        if (corridor[i] === 'S') {
            list.push(i);
        }
    }
    if (list.length == 0 || list.length % 2 == 1) {
        return 0;
    }
    let index = 0;
    let res = 1;
    for (let i = 1; i < list.length - 1; i++) {
        if (index == 0) {
            index = list[i];
        }
        else {
            res = res * (list[i] - index) % MOD;
            index = 0;
        }
    }
    return res;
};
// @lc code=end

