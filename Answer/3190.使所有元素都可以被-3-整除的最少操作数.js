/*
 * @lc app=leetcode.cn id=3190 lang=javascript
 *
 * [3190] 使所有元素都可以被 3 整除的最少操作数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minimumOperations = function (nums) {
    var res = 0;
    nums.forEach(n => {
        if (n % 3 != 0) {
            res++;
        }
    });
    return res;
};
// @lc code=end

