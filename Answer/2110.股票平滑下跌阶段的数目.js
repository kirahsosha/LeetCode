/*
 * @lc app=leetcode.cn id=2110 lang=javascript
 *
 * [2110] 股票平滑下跌阶段的数目
 */

// @lc code=start
/**
 * @param {number[]} prices
 * @return {number}
 */
var getDescentPeriods = function (prices) {
    let res = 0;
    let last = 0;
    let current = 0;
    prices.forEach(price => {
        if (current == 0) {
            current++;
            last = price;
        } else if (price == last - 1) {
            current++;
            last = price;
        } else {
            res += current * (current + 1) / 2;
            current = 1;
            last = price;
        }
    });
    res += current * (current + 1) / 2;
    return res;
};
// @lc code=end

