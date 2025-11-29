/*
 * @lc app=leetcode.cn id=3512 lang=javascript
 *
 * [3512] 使数组和能被 K 整除的最少操作次数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var minOperations = function(nums, k) {
    var res = 0;
    nums.forEach(n => {
        res = (res + n) % k;
    });
    return res;
};
// @lc code=end

