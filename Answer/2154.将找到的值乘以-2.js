/*
 * @lc app=leetcode.cn id=2154 lang=javascript
 *
 * [2154] 将找到的值乘以 2
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} original
 * @return {number}
 */
var findFinalValue = function (nums, original) {
    var set = new Set();
    nums.forEach(num => {
        set.add(num);
    });
    while (set.has(original)) {
        original *= 2;
    }
    return original;
};
// @lc code=end

