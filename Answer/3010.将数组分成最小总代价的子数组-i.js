/*
 * @lc app=leetcode.cn id=3010 lang=javascript
 *
 * [3010] 将数组分成最小总代价的子数组 I
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minimumCost = function (nums) {
    let n1 = nums[0];
    let n2 = Number.MAX_VALUE;
    let n3 = Number.MAX_VALUE;
    nums = nums.slice(1);
    nums.sort((a, b) => a - b);
    return n1 + nums[0] + nums[1];
};
// @lc code=end

