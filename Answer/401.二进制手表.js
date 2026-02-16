/*
 * @lc app=leetcode.cn id=401 lang=javascript
 *
 * [401] 二进制手表
 */

// @lc code=start
/**
 * @param {number} turnedOn
 * @return {string[]}
 */
var readBinaryWatch = function (turnedOn) {
    /**
     * @param {number} number
     * @param {number} digit
     * @param {number} last
     * @return {number[]}
     */
    function ConbineNumber(number, digit, last) {
        let res = [];

        if (last == 0) {
            res.push(number);
            return res;
        } else if (digit == last) {
            return ConbineNumber((number << 1) + 1, digit - 1, last - 1);
        } else if (digit == 0) {
            return ConbineNumber(number << 1, digit, last - 1);
        } else {
            ConbineNumber((number << 1) + 1, digit - 1, last - 1).forEach(num => {
                res.push(num);
            });
            ConbineNumber(number << 1, digit, last - 1).forEach(num => {
                res.push(num);
            });
            return res;
        }
    }

    let nums = ConbineNumber(0, turnedOn, 10);
    let res = [];
    nums.forEach(num => {
        var minute = num >> 4;
        var hour = num & 0x0000000f;
        if (hour < 12 && minute < 60) {
            res.push(hour + ":" + (minute < 10 ? "0" : "") + minute);
        }
    });
    return res;
};
// @lc code=end

