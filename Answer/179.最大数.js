/*
 * @lc app=leetcode.cn id=179 lang=javascript
 *
 * [179] 最大数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {string}
 */
var largestNumber = function (nums) {
    nums.sort((x, y) => {
        if (x == y) {
            return 0;
        }
        if (x == 0) {
            return 1;
        }
        if (y == 0) {
            return -1;
        }
        var i = 1;
        while (i <= y) {
            i *= 10;
        }
        var j = 1;
        while (j <= x) {
            j *= 10;
        }
        if ((i * x + y) > (j * y + x)) {
            return -1;
        }
        return 1;
    })
    if (nums[0] === 0) {
        return "0";
    }
    return nums.join('');
};
// @lc code=end

