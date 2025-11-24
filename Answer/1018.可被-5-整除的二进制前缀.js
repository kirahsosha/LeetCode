/*
 * @lc app=leetcode.cn id=1018 lang=javascript
 *
 * [1018] 可被 5 整除的二进制前缀
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {boolean[]}
 */
var prefixesDivBy5 = function (nums) {
    var num = 0;
    var res = [];
    nums.forEach(i => {
        num = num * 2 + i;
        if (num % 5 == 0) {
            res.push(true);
        }
        else {
            res.push(false);
        }
        num = num % 10;
    });
    return res;
};
// @lc code=end

