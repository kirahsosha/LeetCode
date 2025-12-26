/*
 * @lc app=leetcode.cn id=2483 lang=javascript
 *
 * [2483] 商店的最少代价
 */

// @lc code=start
/**
 * @param {string} customers
 * @return {number}
 */
var bestClosingTime = function (customers) {
    let cost = 0;
    for (let i = 0; i < customers.length; i++) {
        if (customers[i] == 'Y') {
            cost++;
        }
    }
    let min = cost;
    let res = 0;
    for (let i = 0; i < customers.length; i++) {
        if (customers[i] == 'Y') {
            cost--;
        } else {
            cost++;
        }
        if (cost < min) {
            min = cost;
            res = i + 1;
        }
    }
    return res;
};
// @lc code=end

